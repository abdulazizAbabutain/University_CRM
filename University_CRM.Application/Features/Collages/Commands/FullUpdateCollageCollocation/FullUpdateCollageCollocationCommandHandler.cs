using AutoMapper;
using MediatR;
using System.Runtime.CompilerServices;
using University_CRM.Application.Common.Interface;

namespace University_CRM.Application.Features.Collages.Commands;

public class FullUpdateCollageCollocationCommandHandler : IRequestHandler<FullUpdateCollageCollocationCommand>
{
    private readonly ICollageRepository collageRepository;
    private readonly IMapper mapper;

    public FullUpdateCollageCollocationCommandHandler(ICollageRepository collageRepository, IMapper mapper)
    {
        this.collageRepository = collageRepository;
        this.mapper = mapper;
    }
    public async Task<Unit> Handle(FullUpdateCollageCollocationCommand request, CancellationToken cancellationToken)
    {
        var collages = await collageRepository.GetAllAsync(x => request.Collages.Select(y => y.id).Contains(x.CollageId) && !x.IsDeleted);

        mapper.Map(request.Collages, collages);

        await collageRepository.SaveAsync(cancellationToken);
        return Unit.Value; 
    }
}
