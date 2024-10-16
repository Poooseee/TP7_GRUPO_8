﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP7_GRUOPO8
{
    public class AccesoDatos
    {
        string ruta = "Data Source=localhost\\sqlexpress;Initial Catalog=BDSucursales;Integrated Security=True";
        public DataRow obtenerFila(string consulta, string nombreFila)
        {
            SqlConnection cn = new SqlConnection(ruta);
            cn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, ruta);
            adaptador.Fill(ds, nombreFila);
            cn.Close();

            return ds.Tables[nombreFila].Rows[0];
        }

        public string actualizarConsultaProvincias(int id)
        {
            return "select NombreSucursal,DescripcionSucursal,URL_IMAGEN_SUCURSAL where Id_Sucursal =" + id;
        }
    }
}