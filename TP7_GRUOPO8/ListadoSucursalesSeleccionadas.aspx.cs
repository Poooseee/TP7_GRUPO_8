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
            DataTable dt = new DataTable();
            if (Session["SucursalesSeleccionadas"] != null)
            {
                dt = (DataTable)Session["SucursalesSeleccionadas"];
                gvSucursalesSeleccionadas.DataSource = dt;
                gvSucursalesSeleccionadas.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}