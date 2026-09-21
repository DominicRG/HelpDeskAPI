using HelpDesk.Application.Rol.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Rol.Services.Interfaces
{
    public interface IRolService
    {
        Task<List<RolDTO>> GetAllAsync();
        Task<RolDTO> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateRolRequest request);
        Task<bool> UpdateAsync(int id, UpdateRolRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
