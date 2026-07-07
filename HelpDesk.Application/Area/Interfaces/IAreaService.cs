using HelpDesk.Application.Area.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Area.Interfaces
{
    public interface IAreaService
    {
        Task<List<AreaDTO>> GetAllAsync();
        Task<AreaDTO?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateAreaRequest request);
        Task<bool> UpdateAsync(int id, UpdateAreaRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
