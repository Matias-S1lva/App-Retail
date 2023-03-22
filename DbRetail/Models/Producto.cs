using System;
using System.Collections.Generic;

namespace DbRetail.Models
{
    public partial class Producto
    {
        public int Sku { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double? Precio { get; set; }
        public int? CantidadStock { get; set; }
    }
}
