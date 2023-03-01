using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Exceptions;
using University_CRM.Application.Common.Interface;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Departments.Commands;

public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper mapper;

    public AddDepartmentCommandHandler(IRepositoryManager repositoryManager,IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        this.mapper = mapper;
    }
    public async Task<Unit> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
    {
        if (!await _repositoryManager.CollageRepository.IsExistsAsync(x => x.CollageId == request.CollageId && !x.IsDeleted, cancellationToken))
            throw new NotFoundException($"collage with id {request.CollageId} is not found");

        var departmentEntity = mapper.Map<Department>(request);
        await _repositoryManager.DepartmentRepository.AddAsync(departmentEntity);
        await _repositoryManager.DepartmentRepository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
