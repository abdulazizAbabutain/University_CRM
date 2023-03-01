using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Interface;
using University_CRM.Application.Common.Models;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Collages.Queries;

public class GetAllCollageQuery : IRequest<List<CollageDto>>
{
    public bool IncloudDepartment { get; set; } = false;
}
public class GetAllCollageQueryHandler : IRequestHandler<GetAllCollageQuery, List<CollageDto>>
{
    private readonly ICollageRepository collageRepository;
    private readonly IMapper mapper;

    public GetAllCollageQueryHandler(ICollageRepository collageRepository, IMapper mapper)
    {
        this.collageRepository = collageRepository;
        this.mapper = mapper;
    }
    public async Task<List<CollageDto>> Handle(GetAllCollageQuery request, CancellationToken cancellationToken)
    {
        string incloud = null!;
        if (request.IncloudDepartment)
            incloud = nameof(Collage.Departments);

        var collageFromRepo = await collageRepository.GetAllAsync(x => !x.IsDeleted,incloud);
        
        return mapper.Map<List<CollageDto>>(collageFromRepo);
    }
}

