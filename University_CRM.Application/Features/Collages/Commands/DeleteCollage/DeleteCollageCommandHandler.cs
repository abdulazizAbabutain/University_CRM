using MediatR;
using University_CRM.Application.Common.Exceptions;
using University_CRM.Application.Common.Interface;

namespace University_CRM.Application.Features.Collages.Commands
{
    public class DeleteCollageCommandHandler : IRequestHandler<DeleteCollageCommand>
    {
        private readonly ICollageRepository collageRepository;

        public DeleteCollageCommandHandler(ICollageRepository collageRepository)
        {
            this.collageRepository = collageRepository;
        }
        public async Task<Unit> Handle(DeleteCollageCommand request, CancellationToken cancellationToken)
        {
            var collage = await collageRepository.GetAsync(c => c.CollageId == request.Id && !c.IsDeleted, cancellationToken);
            if (collage == null) 
                throw new NotFoundException("not found delete");
            collageRepository.Remove(collage);
            await collageRepository.SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
