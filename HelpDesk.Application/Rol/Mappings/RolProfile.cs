using AutoMapper;
using HelpDesk.Application.Rol.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Rol.Mappings
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<HelpDesk.Domain.Entities.Rol, RolDTO>();
            CreateMap<RolDTO, HelpDesk.Domain.Entities.Rol>();

            CreateMap<CreateRolRequest, HelpDesk.Domain.Entities.Rol>();
            CreateMap<HelpDesk.Domain.Entities.Rol, CreateRolRequest>();

            CreateMap<UpdateRolRequest, HelpDesk.Domain.Entities.Rol>();
            CreateMap<HelpDesk.Domain.Entities.Rol, UpdateRolRequest>();
        }
    }
}
