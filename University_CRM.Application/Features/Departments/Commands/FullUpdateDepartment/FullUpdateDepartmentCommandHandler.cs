using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Exceptions;
using University_CRM.Application.Common.Interface;

namespace University_CRM.Application.Features.Departments.Commands;

public class FullUpdateDepartmentCommandHandler : IRequestHandler<FullUpdateDepartmentCommand>
{
    private readonly IRepositoryManager repositoryManager;
    private readonly IMapper mapper;

    public FullUpdateDepartmentCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.mapper = mapper;
    }
    public async Task<Unit> Handle(FullUpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await repositoryManager.DepartmentRepository.GetAsync(d => d.DepartmentId == request.id, cancellationToken);
        
        if (department == null)
            throw new NotFoundException("test");

        mapper.Map(request, department);
        repositoryManager.DepartmentRepository.Update(department);
        await repositoryManager.DepartmentRepository.SaveAsync(cancellationToken);
        
        return Unit.Value; 
    }
}
