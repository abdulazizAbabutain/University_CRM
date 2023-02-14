using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Interface;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Collages.Commands.AddCollageCollocation
{
    public class AddCollageCollocationCommandHandler : IRequestHandler<AddCollageCollocationCommand>
    {
        private readonly ICollageRepository collageRepository;
        private readonly IMapper mapper;

        public AddCollageCollocationCommandHandler(ICollageRepository collageRepository,IMapper mapper)
        {
            this.collageRepository = collageRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(AddCollageCollocationCommand request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<List<Collage>>(request.Collages);
            await collageRepository.AddRangeAsync(result);
            await collageRepository.SaveAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
