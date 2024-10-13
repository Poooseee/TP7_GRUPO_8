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

        public void agregarSucursalesASession(int idSucursal , string nombreSucursal , string descripcionSucursal)
        {
            DataTable dtSucursales;

            if (Session["SucursalesSeleccionadas"] == null)
            {
                //SI NO EXISTE
                dtSucursales = new DataTable();
                dtSucursales.Columns.Add("Id_Sucursal" , typeof(int));
                dtSucursales.Columns.Add("NombreSucursal", typeof(string));
                dtSucursales.Columns.Add("DescripcionSucursal", typeof(string));

                //GURDAMOS
                Session["SucursalesSeleccionadas"] = dtSucursales;
            }
            else
            {
                //SI YA EXISTE
                dtSucursales = (DataTable)Session["SucursalesSeleccionadas"];
            }

            //YA EXISTE LA SUCURSAL?
            bool isExistSucursal = dtSucursales.AsEnumerable()
                .Any(row => Convert.ToInt32(row["Id_Sucursal"]) == idSucursal);

            if (!isExistSucursal)
            {
                //SI NO EXISTE LA SUCURSAL
                DataRow nuevaFila = dtSucursales.NewRow();

                nuevaFila["Id_Sucursal"] = idSucursal;
                nuevaFila["NombreSucursal"] = nombreSucursal;
                nuevaFila["DescripcionSucursal"] = descripcionSucursal;

                dtSucursales.Rows.Add(nuevaFila);
                Session["SucursalesSeleccionadas"] = dtSucursales;
            }
        }

        protected void lvSucursales_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            ListView listView = (ListView)sender;

            if (listView.DataKeys[e.NewSelectedIndex] != null)
            {
                int idSucursal = Convert.ToInt32(listView.DataKeys[e.NewSelectedIndex].Value);
                string nombreSucursal = ((Label)listView.Items[e.NewSelectedIndex].FindControl("NombreSucursalLabel")).Text;
                string descripcionSucursal = ((Label)listView.Items[e.NewSelectedIndex].FindControl("DescripcionSucursalLabel")).Text;

                agregarSucursalesASession(idSucursal, nombreSucursal, descripcionSucursal);
            }
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}