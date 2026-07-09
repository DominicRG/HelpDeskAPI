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

        public async Task<Area> CreateAsync(Area area)
        {
            _context.Area.Add(area);

            await _context.SaveChangesAsync();

            return area;
        }

        public async Task UpdateAsync(Area area)
        {
            _context.Area.Update(area);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Area area)
        {
            area.Activo = false;

            _context.Area.Update(area);

            await _context.SaveChangesAsync();
        }
    }
}
