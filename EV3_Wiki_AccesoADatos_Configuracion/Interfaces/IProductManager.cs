using EV3_Wiki_AccesoADatos_Configuracion.Models;

namespace EV3_Wiki_AccesoADatos_Configuracion.Interfaces
{
    public interface IProductManager
    {
        List<ProductModel> ProductsList { get; set; }

        Task GetAllProductsFromDbAsync();
    }
}