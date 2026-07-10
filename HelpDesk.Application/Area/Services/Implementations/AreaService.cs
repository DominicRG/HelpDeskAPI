using HelpDesk.Application.Area.DTOs;
using HelpDesk.Application.Area.Services.Interfaces;
using HelpDesk.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Area.Services.Implementations
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _repository;

        public AreaService(IAreaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AreaDTO>> GetAllAsync()
        {
            var areas = await _repository.GetAllAsync();

            return areas.Select(area => new AreaDTO
            {
                IdArea =  area.IdArea,
                Areaa = area.Areaa,
                Nombre = area.Nombre,
                Activo = area.Activo
            }).ToList();
        }

        public Task<int> CreateAsync(CreateAreaRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AreaDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UpdateAreaRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
