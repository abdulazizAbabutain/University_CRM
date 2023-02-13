using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_CRM.Application.Common.Exceptions;
using University_CRM.Application.Common.Interface;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Departments.Commands.AddDepaertment
{
    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand>
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICollageRepository collageRepository;
        private readonly IMapper mapper;

        public AddDepartmentCommandHandler(IDepartmentRepository departmentRepository,
            ICollageRepository collageRepository,
            IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.collageRepository = collageRepository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            if (!await collageRepository.IsExistsAsync(x => x.CollageId == request.CollageId, cancellationToken))
                throw new NotFoundException($"collage with id {request.CollageId} is not found");
            var departmentEntity = mapper.Map<Department>(request);
            await departmentRepository.AddAsync(departmentEntity);
            await departmentRepository.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
