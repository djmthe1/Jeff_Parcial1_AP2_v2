<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroMateriales.aspx.cs" Inherits="Jeff_Parcial1_AP2_v2._0.Registros.RegistroMateriales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 270px;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style4 {
            width: 270px;
        }
        .auto-style5 {
            margin-left: 0px;
        }
        .auto-style6 {
            text-align: right;
            width: 341px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style6"><strong>IdMateriales</strong></td>
                <td>
                    <asp:TextBox ID="IdMaterialesTextBox" runat="server"></asp:TextBox>
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" CssClass="auto-style5" OnClick="BuscarButton_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6"><strong>Descripcion</strong></td>
                <td>
                    <asp:TextBox ID="DescripcionTextBox" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6"><strong>Precio</strong></td>
                <td>
                    <asp:TextBox ID="PrecioTextBox" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
            </td>
            <td class="auto-style2">
                <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
            </td>
            <td>
                <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
            </td>
        </tr>
    </table>
    </form>
    </body>
</html>
