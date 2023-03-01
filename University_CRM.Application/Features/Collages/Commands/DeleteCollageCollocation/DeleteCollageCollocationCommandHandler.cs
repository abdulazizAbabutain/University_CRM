using MediatR;
using University_CRM.Application.Common.Exceptions;
using University_CRM.Application.Common.Interface;

namespace University_CRM.Application.Features.Collages.Commands
{
    public class DeleteCollageCollocationCommandHandler : IRequestHandler<DeleteCollageCollocationCommand>
    {
        private readonly ICollageRepository collageRepository;

        public DeleteCollageCollocationCommandHandler(ICollageRepository collageRepository)
        {
            this.collageRepository = collageRepository;
        }
        public async Task<Unit> Handle(DeleteCollageCollocationCommand request, CancellationToken cancellationToken)
        {
            var collages = await collageRepository.GetAllAsync(c => request.ids.Contains(c.CollageId) && !c.IsDeleted);
            if (!collages.Any() && collages is null)
                throw new NotFoundException("ssssss");
            
            collageRepository.RemoveRange(collages);
            await collageRepository.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
