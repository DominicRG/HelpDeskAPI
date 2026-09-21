using AutoMapper;
using HelpDesk.Application.Rol.DTOs;
using HelpDesk.Application.Rol.Services.Interfaces;
using HelpDesk.Infrastructure.Persistence.Interfaces;
using HelpDesk.Infrastructure.Repositories.Implementations;
using HelpDesk.Infrastructure.Repositories.Interfaces;
using HelpDesk.Shared.Constants;
using HelpDesk.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Rol.Services.Implementations
{
    public class RolService : IRolService
    {
        private readonly IMapper _mapper;
        private readonly IRolRepository _repository;
        private readonly IDatabaseContext _databaseContext;

        public RolService(IMapper mapper, IRolRepository repository, IDatabaseContext databaseContext)
        {
            _mapper = mapper;
            _repository = repository;
            _databaseContext = databaseContext;
        }

        public async Task<int> CreateAsync(CreateRolRequest request)
        {
            if (await _repository.ExistsByNameAsync(request.Nombre)) throw new BusinessException(EntityMessages.AlreadyExist(EntityNames.Rol));

            var rol = _mapper.Map<Domain.Entities.Rol>(request);

            rol.Activo = true;
            _repository.Add(rol);
            await _databaseContext.SaveChangesAsync();
            return rol.IdRol;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id);

            if(rol == null) throw new NotFoundException(EntityMessages.NotFound(EntityNames.Rol));

            rol.Activo = false;
            _repository.Delete(rol);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<RolDTO>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return _mapper.Map<List<RolDTO>>(roles);
        }

        public async Task<RolDTO> GetByIdAsync(int id)
        {
            var rol = await _repository.GetByIdAsync(id);

            if (rol == null) throw new NotFoundException(EntityMessages.NotFound(EntityNames.Rol));

            return _mapper.Map<RolDTO>(rol);
        }

        public async Task<bool> UpdateAsync(int id, UpdateRolRequest request)
        {
            var rol = await _repository.GetByIdAsync(id);

            if(rol == null) throw new NotFoundException(EntityMessages.NotFound(EntityNames.Rol));
            if(await _repository.ExistsByNameAsync(request.Nombre, id)) throw new BusinessException(EntityMessages.AlreadyExist(EntityNames.Rol));

            _mapper.Map(request, rol);
            _repository.Update(rol);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
