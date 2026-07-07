using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Domain.Entities
{
    public class Area
    {
        public int IdArea { get; set; }
        public string Areaa { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificaId { get; set; }
        public DateTime? FechaModifica { get; set; }
    }
}
