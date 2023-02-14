using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Exceptions;
using University_CRM.Application.Common.Interface;

namespace University_CRM.Application.Features.Collages.Commands.ParialUpdateCollage
{
    public class ParialUpdateCollageCommandHandler : IRequestHandler<ParialUpdateCollageCommand>
    {
        private readonly ICollageRepository collageRepository;
        private readonly IMapper mapper;

        public ParialUpdateCollageCommandHandler(ICollageRepository collageRepository, IMapper mapper)
        {
            this.collageRepository = collageRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(ParialUpdateCollageCommand request, CancellationToken cancellationToken)
        {
            var collage = await collageRepository.GetAsync(x => x.CollageId == request.Id, cancellationToken);
            if (collage == null)
                throw new NotFoundException("string string");

            request.document.ApplyTo(collage);

            return Unit.Value;
            
        }
    }
}
