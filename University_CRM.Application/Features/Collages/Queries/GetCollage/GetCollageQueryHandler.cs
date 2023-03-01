using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Exceptions;
using University_CRM.Application.Common.Interface;
using University_CRM.Application.Common.Models;
using University_CRM.Domain.Exceptioon;

namespace University_CRM.Application.Features.Collages.Queries.GetCollage
{
    public class GetCollageQueryHandler : IRequestHandler<GetCollageQuery, CollageDto>
    {
        private readonly ICollageRepository collageRepository;
        private readonly IMapper mapper;

        public GetCollageQueryHandler(ICollageRepository collageRepository, IMapper mapper)
        {
            this.collageRepository = collageRepository;
            this.mapper = mapper;
        }
        public async Task<CollageDto> Handle(GetCollageQuery request, CancellationToken cancellationToken)
        {
            var collage = await collageRepository.GetAsync(x => x.CollageId == request.Id && !x.IsDeleted, cancellationToken);
            if (collage == null)
                throw new NotFoundException($"Collage with id {request.Id} was not found");
            var result = mapper.Map<CollageDto>(collage);
            return result;
        }
    }
}
