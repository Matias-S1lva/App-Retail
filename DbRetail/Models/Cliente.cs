using System;
using System.Collections.Generic;

namespace DbRetail.Models
{
    public partial class Cliente
    {
        public int Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? NumeroTelefono { get; set; }
    }
}
