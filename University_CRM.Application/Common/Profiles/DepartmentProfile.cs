using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_CRM.Application.Common.Models;
using University_CRM.Application.Features.Collages.Commands;
using University_CRM.Application.Features.Departments.Commands.AddDepaertment;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Common.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<AddDepartmentCommand, Department>();
            CreateMap<Department, DepartmentDto>()
               .ForMember(dest => dest.Id, map => map.MapFrom(source => source.DepartmentId));
        }
    }
}
