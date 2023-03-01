using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Exceptions;
using University_CRM.Application.Common.Interface;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Departments.Commands;

public class AddDepaertmentCollocationCommandHandler : IRequestHandler<AddDepaertmentCollocationCommand>
{
    private readonly IRepositoryManager repositoryManager;
    private readonly IMapper mapper;

    public AddDepaertmentCollocationCommandHandler(IRepositoryManager RepositoryManager, IMapper mapper)
    {
        this.repositoryManager = RepositoryManager;
        this.mapper = mapper;
    }
    public async Task<Unit> Handle(AddDepaertmentCollocationCommand request, CancellationToken cancellationToken)
    {
        if (!await repositoryManager.CollageRepository.IsExistsAsync(c => c.CollageId == request.CollageId && !c.IsDeleted, cancellationToken))
            throw new NotFoundException("test");

        var departments = mapper.Map<List<Department>>(request.Department);

        departments = departments.Select(dep =>
        {
            dep.CollageId = request.CollageId;
            return dep;
        }).ToList();

        await repositoryManager.DepartmentRepository.AddRangeAsync(departments);
        await repositoryManager.DepartmentRepository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
