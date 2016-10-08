<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroSolicitudes.aspx.cs" Inherits="Jeff_Parcial1_AP2_v2._0.Registros.RegistroSolicitudes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 24px;
        }
        .auto-style2 {
            text-align: center;
            width: 302px;
        }
        .auto-style3 {
            text-align: right;
            width: 268px;
        }
        .auto-style4 {
            width: 268px;
        }
        .auto-style5 {
            width: 270px;
            text-align: right;
        }
        .auto-style6 {
            width: 133px;
        }
        .auto-style9 {
            width: 302px;
        }
        .auto-style10 {
            width: 302px;
            text-align: right;
        }
        .auto-style12 {
            width: 366px;
        }
        .auto-style14 {
            width: 269px;
        }
        .auto-style15 {
            width: 269px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style5">IdSolicitud:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="IdSolicitudTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Fecha:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="FechaTextBox" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Razon:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="RazonTextBox" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table style="width:100%;">
            <tr>
                <td class="auto-style15">Material:</td>
                <td class="auto-style12">
                    <asp:DropDownList ID="MaterialDropDownList" runat="server" Height="23px" Width="100px">
                    </asp:DropDownList>
&nbsp; Cantidad:
                    <asp:TextBox ID="CantidadTextBox" runat="server" Width="40px"></asp:TextBox>
                &nbsp; Precio:<asp:TextBox ID="PrecioTextBox" runat="server" Width="45px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="AgregarButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style12">
                    <asp:GridView ID="MaterialesGridView" runat="server" AutoGenerateColumns="False" Width="328px">
                    <Columns>
                    <asp:BoundField DataField="Material" HeaderText="Material" ReadOnly="True" SortExpression="MaterialId" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ReadOnly="True" SortExpression="Material" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="True" SortExpression="Cantidad" />
            
</Columns>
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style10">Total:</td>
                <td>
                    <asp:TextBox ID="TotalTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="NuevoButton" runat="server" OnClick="NuevoButton_Click" Text="Nuevo" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="GuardarButton" runat="server" OnClick="GuardarButton_Click" Text="Guardar" />
                </td>
                <td>
                    <asp:Button ID="EliminarButton" runat="server" OnClick="EliminarButton_Click" Text="Eliminar" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
