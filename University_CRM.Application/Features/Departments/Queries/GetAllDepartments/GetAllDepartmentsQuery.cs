using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_CRM.Application.Common.Models;

namespace University_CRM.Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
    {
        public int? CollageId { get; set; }
    }
}
