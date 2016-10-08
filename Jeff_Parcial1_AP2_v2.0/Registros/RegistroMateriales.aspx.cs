using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Jeff_Parcial1_AP2_v2._0.Registros
{
    public partial class RegistroMateriales : System.Web.UI.Page
    {

        Materiales materiales = new Materiales();
        int id, precio = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            ((TextBox)IdMaterialesTextBox).Text = string.Empty;
            ((TextBox)DescripcionTextBox).Text = string.Empty;
            ((TextBox)PrecioTextBox).Text = string.Empty;
        }

        private void ObtenerValores()
        {
            int.TryParse(IdMaterialesTextBox.Text, out id);
            materiales.IdMaterial = id;
            materiales.Descripcion = DescripcionTextBox.Text;
            int.TryParse(PrecioTextBox.Text, out precio);
            materiales.Precio = precio;
        }

        private void DevolverValores()
        {
            IdMaterialesTextBox.Text = materiales.IdMaterial.ToString();
            DescripcionTextBox.Text = materiales.Descripcion;
            PrecioTextBox.Text = materiales.Precio.ToString();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerValores();
                if (IdMaterialesTextBox.Text == "")
                {
                    Response.Write("<script>alert('Debe insertar un Id')</script>");
                }
                else
                {
                    if (materiales.Buscar(materiales.IdMaterial))
                    {
                        DevolverValores();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al buscar')</script>");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerValores();
                if (IdMaterialesTextBox.Text == "")
                {
                    if (DescripcionTextBox.Text != "" && PrecioTextBox.Text != "")
                    {
                        if (materiales.Insertar())
                        {
                            Response.Write("<script>alert('Insertado correctamente')</script>");
                            Limpiar();
                        }
                        else
                        {
                            Response.Write("<script>alert('Error al insertar')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Debe llenar los campos')</script>");
                    }
                }
                else
                {
                    if (DescripcionTextBox.Text != "" && PrecioTextBox.Text != "")
                    {
                        if (materiales.Editar())
                        {
                            Response.Write("<script>alert('Modificado correctamente')</script>");
                            Limpiar();
                        }
                        else
                        {
                            Response.Write("<script>alert('Error al Modificar')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Debe llenar los campos')</script>");
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerValores();
                if (IdMaterialesTextBox.Text == "")
                {
                    Response.Write("<script>alert('Debe insertar un Id')</script>");
                }
                else
                {
                    if (materiales.Eliminar())
                    {
                        Response.Write("<script>alert('Eliminado correctamente')</script>");
                        Limpiar();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al eliminar')</script>");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}