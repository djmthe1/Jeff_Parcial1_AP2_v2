using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Materiales : ClaseMaestra
    {

        public int IdMaterial { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }

        public Materiales(int idMaterial, string descripcion, int precio)
        {
            this.IdMaterial = idMaterial;
            this.Descripcion = descripcion;
            this.Precio = precio;
        }

        public Materiales()
        {

        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("INSERT INTO Materiales (Descripcion, Precio) VALUES ('{0}',{1}) SELECT @@Identity", this.Descripcion, this.Precio));
                return retorno;
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
                retorno = conexion.Ejecutar(string.Format("UPDATE Materiales SET Descripcion='{0}', Precio={1} WHERE IdMaterial={2}", this.Descripcion, this.Precio, this.IdMaterial));
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
                retorno = conexion.Ejecutar(string.Format("DELETE FROM Materiales WHERE IdMaterial={0}", this.IdMaterial));
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

            try
            {
                dt = conexion.ObtenerDatos(string.Format("SELECT * FROM Materiales WHERE IdMaterial={0}", this.IdMaterial));
                if (dt.Rows.Count > 0)
                {
                    this.IdMaterial = (int)dt.Rows[0]["IdMaterial"];
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    this.Precio = (int)dt.Rows[0]["Precio"];
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
            ConexionDb conexion = new ConexionDb();
            string ordenar = "";
            if (!Orden.Equals(""))
                ordenar = " orden by  " + Orden;
            return conexion.ObtenerDatos(("SELECT " + Campos + " FROM Materiales WHERE " + Condicion + ordenar));
        }
    }
}
