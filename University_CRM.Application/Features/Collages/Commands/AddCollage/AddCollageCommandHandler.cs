using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Interface;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Collages.Commands.AddCollage
{
    public class AddCollageCommandHandler : IRequestHandler<AddCollageCommand>
    {
        private readonly ICollageRepository collageRepository;
        private readonly IMapper mapper;

        public AddCollageCommandHandler(ICollageRepository collageRepository,IMapper mapper)
        {
            this.collageRepository = collageRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(AddCollageCommand request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Collage>(request);
            await collageRepository.AddAsync(result);
            await collageRepository.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
