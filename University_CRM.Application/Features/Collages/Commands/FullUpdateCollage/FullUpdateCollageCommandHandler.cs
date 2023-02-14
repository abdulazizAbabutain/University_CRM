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
        var collgaeFromRepo = await collageRepository.GetAsync(c => c.CollageId == request.id, cancellationToken);
        if (collgaeFromRepo is null)
            throw new NotFoundException($"collage with id {request.id} was not found");


        collgaeFromRepo.UpdateNames(request.NameArabic,request.NameEnglish);
        collgaeFromRepo.UpdateDescriptions(request.DescriptionArabic, request.DescriptionEnglish);

        //var collage = mapper.Map<Collage>(request);

        await collageRepository.SaveAsync(cancellationToken);
        
        return Unit.Value;
    }
}
