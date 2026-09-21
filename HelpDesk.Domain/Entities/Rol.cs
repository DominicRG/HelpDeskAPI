using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Domain.Entities
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
