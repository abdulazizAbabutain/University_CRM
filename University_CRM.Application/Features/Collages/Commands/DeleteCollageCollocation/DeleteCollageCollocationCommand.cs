using MediatR;

namespace University_CRM.Application.Features.Collages.Commands
{
    public class DeleteCollageCollocationCommand : IRequest
    {
        public List<int> ids { get; set; }
    }
}
