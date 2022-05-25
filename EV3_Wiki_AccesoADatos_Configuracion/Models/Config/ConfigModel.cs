using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV3_Wiki_AccesoADatos_Configuracion.Models.Config
{
    public class ConfigModel
    {
        public DataLayerModel DataLayer { get; set; }
        public GeneralSettingsModel GeneralSettings { get; set; } 

        public ConfigModel ()
        {
            DataLayer = new DataLayerModel ();
            GeneralSettings = new GeneralSettingsModel ();
        }
    }
}
