using EV3_Wiki_AccesoADatos_Configuracion.Interfaces;
using EV3_Wiki_AccesoADatos_Configuracion.Manager;
using MyLib.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV3_Wiki_AccesoADatos_Configuracion.Factories
{
    public class ProductManagerFactory : IProductManagerFactory
    {

        public IProductManager Create(SqlServer myDb)
        {
            return new ProductManager(myDb);
        }

    }
}
