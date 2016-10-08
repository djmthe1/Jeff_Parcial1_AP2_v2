using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace Jeff_Parcial1_AP2_v2._0.Registros
{
    public partial class RegistroSolicitudes : System.Web.UI.Page
    {

        Solicitudes solicitudes = new Solicitudes();
        Materiales mateiales = new Materiales();
        int id, total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InsertarColumnas();
            }
            LlenarDropDownList();
        }

        private void LlenarDropDownList()
        {
            DataTable dtMateriales = new DataTable();
            dtMateriales = mateiales.Listado("*", "1=1", "");
            MaterialDropDownList.DataSource = dtMateriales;
            MaterialDropDownList.DataTextField = "Descripcion";
            MaterialDropDownList.DataValueField = "IdMaterial";
            MaterialDropDownList.DataBind();
        }

        private void Limpiar()
        {
            ((TextBox)IdSolicitudTextBox).Text = string.Empty;
            ((TextBox)FechaTextBox).Text = string.Empty;
            ((TextBox)RazonTextBox).Text = string.Empty;
            MaterialDropDownList.SelectedIndex = -1;
            ((TextBox)CantidadTextBox).Text = string.Empty;
            ((TextBox)PrecioTextBox).Text = string.Empty;
            MaterialesGridView.DataSource = null;
            ((TextBox)TotalTextBox).Text = string.Empty;
            InsertarColumnas();
            ObtenerValoresGridView();
        }

        public void InsertarColumnas()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] 
            {
                new DataColumn("Material"),
                new DataColumn("Cantidad"),
                new DataColumn("Precio")
            });
            ViewState["Detalle"] = dt;
        }

        public void ObtenerValoresGridView()
        {
            MaterialesGridView.DataSource = (DataTable)ViewState["Detalle"];
            MaterialesGridView.DataBind();
        }
        
        private void ObtenerValores()
        {
            int.TryParse(IdSolicitudTextBox.Text, out id);
            solicitudes.IdSolicitud = id;
            solicitudes.Fecha = FechaTextBox.Text;
            solicitudes.Razon = RazonTextBox.Text;
            int.TryParse(TotalTextBox.Text, out total);
            solicitudes.Total = total;
            foreach (GridViewRow row in MaterialesGridView.Rows)
            {
                solicitudes.AgregarDetalle(Convert.ToInt32(row.Cells[0].Text), Convert.ToInt32(row.Cells[1].Text), Convert.ToInt32(row.Cells[2].Text));
            }
        }
        
        private void DevolverValores()
        {
            IdSolicitudTextBox.Text = solicitudes.IdSolicitud.ToString();
            FechaTextBox.Text = solicitudes.Fecha;
            RazonTextBox.Text = solicitudes.Razon;
            TotalTextBox.Text = solicitudes.Total.ToString();
            foreach (var item in solicitudes.detalles)
            {
                DataTable dt = (DataTable)ViewState["Detalle"];
                dt.Rows.Add(item.IdMaterial, item.Cantidad, item.Precio);
                ViewState["Detalle"] = dt;
                ObtenerValoresGridView();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerValores();
                if (IdSolicitudTextBox.Text != "")
                {
                    if (solicitudes.Buscar(solicitudes.IdSolicitud))
                    {
                        DevolverValores();
                    }
                    else
                    {
                        Response.Write("<script>alert('Id no encontrado')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Debe insertar un Id')</script>");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CalculoTotal()
        {
            int Anterior, presente = 0;
            int.TryParse(TotalTextBox.Text, out Anterior);
            int precio, cantidad, total = 0;
            int.TryParse(PrecioTextBox.Text, out precio);
            int.TryParse(CantidadTextBox.Text, out cantidad);
            total = precio * cantidad;
            presente = Anterior + total;
            TotalTextBox.Text = presente.ToString();
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MaterialDropDownList.Text != "" && CantidadTextBox.Text != "" && PrecioTextBox.Text != "")
                {
                    DataTable dt = (DataTable)ViewState["Detalle"];

                    dt.Rows.Add(MaterialDropDownList.SelectedValue, CantidadTextBox.Text, PrecioTextBox.Text);
                    ViewState["Detalle"] = dt;
                    ObtenerValoresGridView();

                    CalculoTotal();

                    MaterialDropDownList.SelectedIndex = -1;
                    ((TextBox)CantidadTextBox).Text = string.Empty;
                    ((TextBox)PrecioTextBox).Text = string.Empty;
                }
                else
                {
                    Response.Write("<script>alert('Debe llenar los campos requeridos')</script>");
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
                if (IdSolicitudTextBox.Text == "")
                {
                    if (FechaTextBox.Text != "" && RazonTextBox.Text != "" && TotalTextBox.Text != "")
                    {
                        if (solicitudes.Insertar())
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
                    if (FechaTextBox.Text != "" && RazonTextBox.Text != "" && TotalTextBox.Text != "")
                    {
                        if (solicitudes.Editar())
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
                if (IdSolicitudTextBox.Text == "")
                {
                    Response.Write("<script>alert('Debe insertar un Id')</script>");
                }
                else
                {
                    if (solicitudes.Eliminar())
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