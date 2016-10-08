<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroPortada.aspx.cs" Inherits="Jeff_Parcial1_AP2_v2._0.Registros.RegistroPortada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: center;
            text-decoration: underline;
            color: #FF0000;
        }
        .auto-style3 {
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
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2"><strong><em>Primer Parcial Aplicada II</em></strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2"><strong><em>Jeff McGrath</em></strong></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="MaterialesButton" runat="server" Text="Materiales" OnClick="MaterialesButton_Click" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="SolicitudesButton" runat="server" Text="Solicitudes" OnClick="SolicitudesButton_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
