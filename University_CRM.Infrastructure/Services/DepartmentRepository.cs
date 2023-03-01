using University_CRM.Application.Common.Interface;
using University_CRM.Domain.Entities;
using University_CRM.Infrastructure.Persistence;

namespace University_CRM.Infrastructure.Services
{
    public class DepartmentRepository :  GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationContext context) 
            : base(context)
        {
        }
    }
}
