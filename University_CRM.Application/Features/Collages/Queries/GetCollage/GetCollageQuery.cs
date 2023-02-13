using MediatR;
using University_CRM.Application.Common.Models;

namespace University_CRM.Application.Features.Collages.Queries
{
    public class GetCollageQuery : IRequest<CollageDto>
    {
        public int Id { get; set; }
    }
}
