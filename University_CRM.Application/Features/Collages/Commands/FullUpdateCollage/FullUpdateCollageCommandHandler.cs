using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Exceptions;
using University_CRM.Application.Common.Interface;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Collages.Commands;

public class FullUpdateCollageCommandHandler : IRequestHandler<FullUpdateCollageCommand>
{
    private readonly ICollageRepository collageRepository;
    private readonly IMapper mapper;

    public FullUpdateCollageCommandHandler(ICollageRepository collageRepository, IMapper mapper)
	{
        this.collageRepository = collageRepository;
        this.mapper = mapper;
    }

    public async Task<Unit> Handle(FullUpdateCollageCommand request, CancellationToken cancellationToken)
    {
        if(!await collageRepository.IsExistsAsync(c => c.CollageId == request.id, cancellationToken))
            throw new NotFoundException($"collage with id {request.id} was not found");

        var collage = mapper.Map<Collage>(request);
        collageRepository.Update(collage);
        await collageRepository.SaveAsync(cancellationToken);
        
        return Unit.Value;
    }
}
