using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SolicitudesDetalle
    {
        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public int IdMaterial { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }

        public SolicitudesDetalle(int idMaterial, int cantidad, int precio)
        {
            this.IdMaterial = idMaterial;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

        public SolicitudesDetalle()
        {

        }
        
    }
}
