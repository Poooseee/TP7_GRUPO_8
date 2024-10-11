<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionadas.aspx.cs" Inherits="TP7_GRUOPO8.ListadoSucursalesSeleccionadas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style3 {
            width: 100%;
            margin-left: 382px;
        }
        .auto-style4 {
            width: 100%;
            font-size: x-large;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 40px">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SeleccionarSucursales.aspx">Listado de Sucursales</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ListadoSucursalesSeleccionadas.aspx">Mostrar Sucursales Seleccionadas</asp:HyperLink>
            <br />
            <br />
            <table class="auto-style3">
                <tr>
                    <td><strong><span class="auto-style4">Mostrar sucursales seleccionadas</span></strong></td>
                </tr>
            </table>
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="ID_Sucursal" />
                    <asp:BoundField HeaderText="NOMBRE" />
                    <asp:BoundField HeaderText="DESCRIPCIÓN" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
