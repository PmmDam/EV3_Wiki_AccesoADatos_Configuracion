using EV3_Wiki_AccesoADatos_Configuracion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib.SQL;
using System.Data;
using Microsoft.Data.SqlClient;
using EV3_Wiki_AccesoADatos_Configuracion.Interfaces;

namespace EV3_Wiki_AccesoADatos_Configuracion.Manager
{
    public class ProductManager : IProductManager
    {
        SqlServer myDb { get; set; }
        public ProductManager(SqlServer myDb)
        {
            this.myDb = myDb;
        }



        public List<ProductModel> ProductsList { get; set; }

        public async Task GetAllProductsFromDbAsync()
        {

            await this.myDb.ExecuteReaderAsync("ListProducts", CommandType.StoredProcedure, ReadAllProducts);

        }


        private async Task ReadAllProducts(SqlDataReader reader)
        {

            this.ProductsList = new List<ProductModel>();
            if (reader.HasRows)
            {

                while (await reader.ReadAsync())
                {

                    ProductModel product = new ProductModel();

                    if (!reader.IsDBNull(0))
                    {
                        product.RawId = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        product.Name = reader.GetString(1);
                    }
                    if (product != null)
                        this.ProductsList.Add(product);
                }
            }

        }





    }
}
