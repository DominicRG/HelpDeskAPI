using AutoMapper;
using HelpDesk.Domain.Entities;
using HelpDesk.Application.Area.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Area.Mappings
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<CreateAreaRequest, HelpDesk.Domain.Entities.Area>();
            CreateMap<HelpDesk.Domain.Entities.Area, CreateAreaRequest>();

            CreateMap<UpdateAreaRequest, HelpDesk.Domain.Entities.Area>();
            CreateMap<HelpDesk.Domain.Entities.Area, UpdateAreaRequest>();

            CreateMap<HelpDesk.Domain.Entities.Area, AreaDTO>();
            CreateMap<AreaDTO, HelpDesk.Domain.Entities.Area>();
        }
    }
}
