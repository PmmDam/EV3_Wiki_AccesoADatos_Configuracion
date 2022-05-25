using MyLib.SQL;

namespace EV3_Wiki_AccesoADatos_Configuracion.Interfaces
{
    public interface IProductManagerFactory
    {
        IProductManager Create(SqlServer myDb);
    }
}