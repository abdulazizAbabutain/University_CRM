using AutoMapper;
using University_CRM.Application.Common.Models;
using University_CRM.Application.Features.Departments.Commands;
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
            CreateMap<DepartmentCommand, Department>();
            
            CreateMap<FullUpdateDepartmentCommand, Department>()
                .ForMember(dest => dest.DepartmentId, map => map.MapFrom(source => source.id));
        }
    }
}
