using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TP7_GRUOPO8
{
    public partial class ListadoSucursalesSeleccionadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["SucursalesSeleccionadas"] != null)
            {
                
                gvSucursalesSeleccionadas.DataSource = Session["SucursalesSeleccionadas"];
                gvSucursalesSeleccionadas.DataBind();
                lblNoSeleccion.Text = "";
            }
            else
            {
                lblNoSeleccion.Text = "No se han seleccionado sucursales";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Session["SucursalesSeleccionadas"] != null)
            {
                lblNoSeleccion.Text = "Se han eliminado las sucursales seleccionadas";
                Session["SucursalesSeleccionadas"] = null;
                gvSucursalesSeleccionadas.DataSource = Session["SucursalesSeleccionadas"];
                gvSucursalesSeleccionadas.DataBind();
            }
        }
    }
}