using AutoMapper;
using MediatR;
using University_CRM.Application.Common.Interface;
using University_CRM.Application.Common.Models;

namespace University_CRM.Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICollageRepository collageRepository;
        private readonly IMapper mapper;

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository, ICollageRepository collageRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.collageRepository = collageRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        { 
            var departmentsFromRepo = await departmentRepository.GetAllAsync(dep => (dep.CollageId == request.CollageId || request.CollageId == null));
            return mapper.Map<List<DepartmentDto>>(departmentsFromRepo);
        }
    }
}
