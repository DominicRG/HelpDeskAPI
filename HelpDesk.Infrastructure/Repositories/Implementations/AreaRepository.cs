 using HelpDesk.Domain.Entities;
using HelpDesk.Infrastructure.Persistence;
using HelpDesk.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Infrastructure.Repositories.Implementations
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ApplicationDbContext _context;

        public AreaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Area>> GetAllAsync()
        {
            return await _context.Area
                .AsNoTracking()
                .Where(x => x.Activo)
                .OrderBy(x => x.Nombre)
                .ToListAsync();
        }

        public async Task<Area?> GetByIdAsync(int id)
        {
            return await _context.Area
                .FirstOrDefaultAsync(x => x.IdArea == id);
        }

        public void Add(Area area)
        {
            _context.Area.Add(area);
        }

        public void Update(Area area)
        {
            _context.Area.Update(area);
        }

        public void Delete(Area area)
        {
            area.Activo = false;
            _context.Area.Update(area);
        }
    }
}
