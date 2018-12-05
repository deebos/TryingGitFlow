using AutoMapper;
using EAI.Template.API.Model;
using EAI.Template.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EAI.Template.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Applications, ApplicationsDTO>();
        }
    }
}
