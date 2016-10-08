using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jeff_Parcial1_AP2_v2._0.Registros
{
    public partial class RegistroPortada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MaterialesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroMateriales.aspx");
        }

        protected void SolicitudesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroSolicitudes.aspx");
        }
    }
}