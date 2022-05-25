using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV3_Wiki_AccesoADatos_Configuracion.Models.Config
{
    public class DataLayerModel
    {
        public string ServerName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string DbName { get; set; }
        public string ConnectionString { get; set; }
    }
}
