using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EV3_Wiki_AccesoADatos_Configuracion.Models
{
    public class ProductModel
    {
        private int _Id { get; set; }

        [JsonIgnore]
        public int RawId
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }

        public string Id
        {
            get
            {
                return this._Id.ToString();
            }

            set
            {
                this._Id = int.Parse(value);
            }
        }

        private string _name { get; set; }
        public string Name
        {
            get
            {
                return string.IsNullOrEmpty(this._name) ? string.Empty : this._name;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._name = value;
                }
                else
                {
                    this._name = string.Empty;
                }
            }
        }


        private double _price { get; set; }


        [JsonIgnore]
        public double RawPrice
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
            }

        }

        public string Price
        {
            get
            {
                return this._price.ToString();
            }

            set
            {
                this._price = double.Parse(value);
            }
        }


        private int _stock { get; set; }


        [JsonIgnore]
        public int RawStock
        {
            get
            {
                return this._stock;
            }
            set
            {
                this._stock = value;
            }

        }

        public string Stock
        {
            get
            {
                return this._stock.ToString();
            }

            set
            {
                this._stock = int.Parse(value);
            }
        }

        private bool _isAvailable { get; set; }

        public bool RawIsAvailable
        {
            get
            {
                return this._isAvailable;
            }
            set
            {
                this._isAvailable = value;
            }
        }

        public string IsAvailable
        {
            get
            {
                return this._isAvailable ? "Disponible" : "No Disponible";
            }
            set
            {
                switch (value.ToLower())
                {
                    case "disponible":
                        this._isAvailable = true;
                        break;

                    case "1":
                        this._isAvailable = true;
                        break;
                    case "true":
                        this._isAvailable = true;
                        break;

                    default:
                        this._isAvailable = false;
                        break;
                }
            }
        }



    }
}
