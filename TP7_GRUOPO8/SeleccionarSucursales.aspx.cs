using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace TP7_GRUOPO8
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SucursalesSeleccionadas"] == null)
            {
                lblSeleccion.Text = "Aún no se ha seleccionado ninguna sucursal";
            }
        }

        public bool agregarSucursalesASession(int idSucursal)
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
                Session["SucursalesSeleccionadas"] = dtSucursales;
                return true;
            }
            else
            {
                return false;
            }
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
                GestionSucursales gSucursales = new GestionSucursales();
                DataRow sucursal = gSucursales.ObtenerSucursal(id);
                string nombreSucursal = sucursal["NombreSucursal"].ToString();
                if (agregarSucursalesASession(id))
                {
                    lblSeleccion.Text = "Se ha seleccionado la sucursal: " + "<br>";
                    lblLista.Text += "-"+nombreSucursal + "<br>";
                    
                }
                else
                {
                    lblSeleccion.Text = "Esta sucursal ya ha sido seleccionada";
                }
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

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Button BtnSeleccionar = (Button) sender;
            BtnSeleccionar.Text = "Seleccionado";
            BtnSeleccionar.BackColor = Color.GreenYellow;
        }
    }
}