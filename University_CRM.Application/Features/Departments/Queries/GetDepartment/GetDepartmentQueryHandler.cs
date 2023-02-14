using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_CRM.Application.Common.Exceptions;
using University_CRM.Application.Common.Interface;
using University_CRM.Application.Common.Models;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Departments.Queries.GetDepartment
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, DepartmentDto>
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IMapper mapper;

        public GetDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }
        public async Task<DepartmentDto> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            if (!await departmentRepository.IsExistsAsync(x => x.DepartmentId == request.Id, cancellationToken))
                throw new NotFoundException($"the {nameof(Department)} with id {request.Id} was not found");
            var departmentFromRepo = await departmentRepository.GetAsync(x => x.DepartmentId == request.Id,cancellationToken);
            return mapper.Map<DepartmentDto>(departmentFromRepo);
        }
    }
}
