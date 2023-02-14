using MediatR;

namespace University_CRM.Application.Features.Collages.Commands
{
    public class DeleteCollageCommand : IRequest
    {
        public int Id { get; set; }
    }
}
