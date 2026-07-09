using HelpDesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Infrastructure.Repositories.Interfaces
{
    public interface IAreaRepository
    {
        Task<List<Area>> GetAllAsync();
        Task<Area?> GetByIdAsync(int id);
        Task<Area> CreateAsync(Area area);
        Task UpdateAsync(Area area);
        Task DeleteAsync(Area area);
    }
}
