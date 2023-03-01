using MediatR;

namespace University_CRM.Application.Features.Departments.Commands;

public class AddDepaertmentCollocationCommand : IRequest
{
    public int CollageId { get; set; }
    public List<DepartmentCommand> Department { get; set; }
}
