using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TP7_GRUOPO8
{
    public class GestionSucursales
    {
        AccesoDatos datos = new AccesoDatos();

        public DataRow ObtenerSucursal(int id)
        {
            string consulta = "Select Id_Sucursal, NombreSucursal,DescripcionSucursal FROM Sucursal WHERE Id_Sucursal = " + id;
            return datos.obtenerFila(consulta, "SucursalElegida");
        }

    }
}