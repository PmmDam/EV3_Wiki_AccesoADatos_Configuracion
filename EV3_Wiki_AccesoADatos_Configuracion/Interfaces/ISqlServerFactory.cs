﻿using MyLib.SQL;

namespace EV3_Wiki_AccesoADatos_Configuracion.Interfaces
{
    public interface ISqlServerFactory
    {
        SqlServer Create(string ConnectionString);
    }
}