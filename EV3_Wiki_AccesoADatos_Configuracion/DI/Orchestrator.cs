using EV3_Wiki_AccesoADatos_Configuracion.Interfaces;
using EV3_Wiki_AccesoADatos_Configuracion.Models.Config;
using Microsoft.Extensions.Options;
using MyLib.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV3_Wiki_AccesoADatos_Configuracion.DI
{
    public class Orchestrator : IOrchestrator
    {

        // Configuración
        private IOptionsMonitor<ConfigModel> _options { get; set; }
        private ConfigModel _config { get; set; }
        private IDisposable _optionsDisposable { get; set; }



        //Dependencias del constructos
        
        private IProductManagerFactory _productManagerFactory { get; set; }
        private ISqlServerFactory _myDbFactory { get; set; }



        

        public Orchestrator(IOptionsMonitor<ConfigModel> options, IProductManagerFactory productManagerFactory, ISqlServerFactory myDbFactory)
        {

            //Configuración
            this._options = options;
            this._config = this._options.CurrentValue;
            this._optionsDisposable = options.OnChange<ConfigModel>(ReadNewConfig);

            // Dependencias
            this._productManagerFactory = productManagerFactory;
            this._myDbFactory = myDbFactory;
        }


        private void ReadNewConfig(ConfigModel newConfig)
        {
            if (this._optionsDisposable != null)
            {
                this._optionsDisposable.Dispose();
                this._optionsDisposable = null;
            }
            this._config = newConfig;
            this._optionsDisposable = this._options.OnChange<ConfigModel>(ReadNewConfig);
        }


        public async Task Play()
        {

            SqlServer myDb = this._myDbFactory.Create(this._config.DataLayer.ConnectionString);
            IProductManager productManager = this._productManagerFactory.Create(myDb);
            
            await productManager.GetAllProductsFromDbAsync();
           
            Console.WriteLine(productManager.ProductsList[0].Name);


        }


         

    }
}
