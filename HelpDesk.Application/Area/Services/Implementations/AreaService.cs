using HelpDesk.Application.Area.DTOs;
using HelpDesk.Application.Area.Services.Interfaces;
using HelpDesk.Domain.Entities;
using HelpDesk.Infrastructure.Persistence.Interfaces;
using HelpDesk.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Area.Services.Implementations
{
    public class AreaService : IAreaService
    {
        //Repositorios de entities
        private readonly IAreaRepository _repository;

        //Interfaz para guardar cambios globales
        private readonly IDatabaseContext _database;

        public AreaService(IAreaRepository repository, IDatabaseContext database)
        {
            _repository = repository;
            _database = database;
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

        public async Task<AreaDTO?> GetByIdAsync(int id)
        {
            var area = await _repository.GetByIdAsync(id);

            if(area == null)
                return null;

            return new AreaDTO
            {
                IdArea = area.IdArea,
                Areaa = area.Areaa,
                Nombre = area.Nombre,
                Activo = area.Activo
            };
        }

        public async Task<int> CreateAsync(CreateAreaRequest request)
        {
            if (await _repository.ExistByCodeAsync(request.Areaa)) throw new Exception("Ya existe un area registrada con ese código");

            var area = new HelpDesk.Domain.Entities.Area
            {
                Areaa = request.Areaa,
                Nombre = request.Nombre,
                Activo = true,
                UsuarioCreacionId = 0,
                FechaCreacion = DateTime.Now
            };

            _repository.Add(area);
            await _database.SaveChangesAsync();

            return area.IdArea;
        }

        public async Task<bool> UpdateAsync(int id, UpdateAreaRequest request)
        {
            var area = await _repository.GetByIdAsync(id);

            if (area == null)
                throw new Exception("Área no encontrada.");

            if (await _repository.ExistByCodeAsync(request.Areaa, id))
                throw new Exception("Ya existe un área con ese codigo.");

            area.Areaa = request.Areaa;
            area.Nombre = request.Nombre;
            area.Activo = request.Activo;

            area.UsuarioModificaId = 1; //Ponemos un id provisional
            area.FechaModifica = DateTime.Now;

            _repository.Update(area);

            await _database.SaveChangesAsync();

            return true;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
