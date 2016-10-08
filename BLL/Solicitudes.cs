using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Solicitudes : ClaseMaestra
    {
        public int IdSolicitud { get; set; }
        public string Fecha { get; set; }
        public string Razon { get; set; }
        public int Total { get; set; }
        public List<SolicitudesDetalle> detalles { get; set; }

        public Solicitudes(int idSolicitud , string fecha, string razon, int total)
        {
            this.IdSolicitud = idSolicitud;
            this.Fecha = fecha;
            this.Razon = razon;
            this.Total = total;
        }

        public Solicitudes()
        {
            detalles = new List<SolicitudesDetalle>();
        }

        public void AgregarDetalle(int idMaterial, int cantidad, int precio)
        {
            detalles.Add(new SolicitudesDetalle(idMaterial, cantidad, precio));
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            int retorno = 0;
            object Identity;
            try
            {
                Identity = conexion.ObtenerValor(string.Format("INSERT INTO Solicitudes (Fecha, Razon, Total) VALUES ('{0}', '{1}', {2}) SELECT @@Identity", this.Fecha, this.Razon, this.Total));
                int.TryParse(Identity.ToString(), out retorno);
                if (retorno > 0)
                {
                    foreach (var detalle in detalles)
                    {
                        conexion.Ejecutar(string.Format("INSERT INTO SolicitudesDetalle (IdSolicitud, IdMaterial, Cantidad, Precio) VALUES ({0},{1},{2},{3})", retorno, detalle.IdMaterial, detalle.Cantidad, detalle.Precio));
                    }
                }
                return retorno > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("UPDATE Solicitudes SET Fecha='{0}', Razon='{1}', Total={2} WHERE IdSolicitud={3}", this.Fecha, this.Razon, this.Total, this.IdSolicitud));
                if (retorno)
                {
                    conexion.Ejecutar(string.Format("DELETE FROM SolicitudesDetalle WHERE IdSolicitud={0}", this.IdSolicitud));
                    foreach (var detalle in detalles)
                    {
                        conexion.Ejecutar(string.Format("INSERT INTO SolicitudesDetalle (IdSolicitud, IdMaterial, Cantidad, Precio) VALUES ({0},{1},{2},{3})", IdSolicitud, detalle.IdMaterial, detalle.Cantidad, detalle.Precio));
                    }                                                                            
                }                                                                                 
                return retorno;                                                                  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno;
            try
            {
                retorno = conexion.Ejecutar(string.Format("DELETE FROM SolicitudesDetalle WHERE IdSolicitud={0}", this.IdSolicitud));
                if (retorno)
                {
                    conexion.Ejecutar(string.Format("DELETE FROM Solicitudes WHERE IdSolicitud={0}", this.IdSolicitud));
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable dtdetalle = new DataTable();

            try
            {
                dt = conexion.ObtenerDatos("SELECT * FROM Solicitudes WHERE IdSolicitud=" + IdSolicitud);
                if (dt.Rows.Count > 0)
                {
                    this.IdSolicitud = (int)dt.Rows[0]["IdSolicitud"];
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.Razon = dt.Rows[0]["Razon"].ToString();
                    this.Total = (int)dt.Rows[0]["Total"];

                    dtdetalle = conexion.ObtenerDatos("SELECT * FROM SolicitudesDetalle WHERE IdSolicitud=" + IdSolicitud);
                    foreach (DataRow var in dtdetalle.Rows)
                    {
                        this.AgregarDetalle((int)var["IdMaterial"], (int)var["Cantidad"], (int)var["Precio"]);
                    }
                }
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            throw new NotImplementedException();
        }
    }
}
