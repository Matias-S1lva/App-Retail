using System;
using System.Collections.Generic;

namespace DbRetail.Models
{
    public partial class Vendedor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? CorreoElectronico { get; set; }
    }
}
