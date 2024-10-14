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
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void agregarSucursalesASession(int idSucursal)
        {
            DataTable dtSucursales = new DataTable();
            if (Session["SucursalesSeleccionadas"] == null)
            {
                //SI NO EXISTE
                dtSucursales.Columns.Add("Id_Sucursal" , typeof(int));
                dtSucursales.Columns.Add("NombreSucursal", typeof(string));
                dtSucursales.Columns.Add("DescripcionSucursal", typeof(string));

                //GURDAMOS
                Session["SucursalesSeleccionadas"] = dtSucursales;
            }
               //SI YA EXISTE
              dtSucursales = (DataTable)Session["SucursalesSeleccionadas"];

            // obtengo la informacion 
            GestionSucursales gSucursales = new GestionSucursales();
            DataRow nuevaFila = gSucursales.ObtenerSucursal(idSucursal);
            string nombre = nuevaFila["NombreSucursal"].ToString();
            string Descripcion = nuevaFila["DescripcionSucursal"].ToString();

            // verifico y agrego
            if (Repetida(dtSucursales, idSucursal) == false)
            {
                dtSucursales.Rows.Add(idSucursal, nombre, Descripcion);
               
            }
            Session["SucursalesSeleccionadas"] = dtSucursales;
        }
        public bool Repetida(DataTable tabla, int id)
        {
            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["Id_Sucursal"].ToString() == id.ToString())
                {
                    return true;
                }

            }
            return false;
        }
        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {          
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "EventoSeleccionar")
            {
                agregarSucursalesASession(id);
            }
        }

        protected void lvSucursales_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void btnProvincias_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "SeleccionarProvincias")
            {
                SqlDataSource1.SelectCommand = "SELECT [NombreSucursal], [DescripcionSucursal], " +
                    "[URL_Imagen_Sucursal], [Id_Sucursal] FROM [Sucursal] " +
                    "where [Id_ProvinciaSucursal] ="+ e.CommandArgument.ToString();
            }
        }

        protected void btnBuscarTodas_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT[NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal] FROM[Sucursal]";
            txtNombreDeSucursal.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT[NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal] FROM[Sucursal] WHERE [NombreSucursal] LIKE '" + txtNombreDeSucursal.Text + "%'";
            txtNombreDeSucursal.Text = "";
        }
    }
}