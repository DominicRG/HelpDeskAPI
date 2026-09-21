using HelpDesk.Domain.Entities;
using HelpDesk.Infrastructure.Persistence;
using HelpDesk.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Infrastructure.Repositories.Implementations
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        public RolRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByNameAsync(string nombre, int? id = null)
        {
            return await _context.Rol.AnyAsync(x => x.Nombre == nombre && (!id.HasValue || x.IdRol != id.Value));
        }
    }
}
