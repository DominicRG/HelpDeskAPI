using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Area.DTOs
{
    public class UpdateAreaRequest
    {
        public string Areaa { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
