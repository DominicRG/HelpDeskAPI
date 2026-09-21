using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Rol.DTOs
{
    public class CreateRolRequest
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
