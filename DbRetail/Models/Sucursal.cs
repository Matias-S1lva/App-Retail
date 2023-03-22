using System;
using System.Collections.Generic;

namespace DbRetail.Models
{
    public partial class Sucursal
    {
        public int Cuit { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? NumeroTelefono { get; set; }
    }
}
