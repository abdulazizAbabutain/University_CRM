using AutoMapper;
using University_CRM.Application.Common.Models;
using University_CRM.Application.Features.Collages.Commands;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Common.Profiles
{
    public class CollageProfiles : Profile
    {
        public CollageProfiles()
        {
            CreateMap<Collage, CollageDto>()
                .ForMember(dest => dest.Id, map => map.MapFrom(source => source.CollageId));
            CreateMap<AddCollageCommand, Collage>();
            CreateMap<FullUpdateCollageCommand, Collage>()
             .ForMember(dest => dest.CollageId, map => map.MapFrom(source => source.id));
            
        }
    }
}
