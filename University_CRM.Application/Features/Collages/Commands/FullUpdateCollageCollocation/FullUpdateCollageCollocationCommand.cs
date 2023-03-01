using MediatR;

namespace University_CRM.Application.Features.Collages.Commands;

public class FullUpdateCollageCollocationCommand : IRequest
{
    public List<FullUpdateCollageCommand> Collages { get; set; }
}
