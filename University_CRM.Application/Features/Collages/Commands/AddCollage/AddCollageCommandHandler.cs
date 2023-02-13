using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Interface;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Collages.Commands.AddCollage
{
    public class AddCollageCommandHandler : IRequestHandler<AddCollageCommand>
    {
        private readonly ICollageRepository _collageRepository;
        private readonly IMapper mapper;

        public AddCollageCommandHandler(ICollageRepository collageRepository,IMapper mapper)
        {
            _collageRepository = collageRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(AddCollageCommand request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<Collage>(request);
            await _collageRepository.AddAsync(result);
            await _collageRepository.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
