using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_CRM.Application.Common.Models;

namespace University_CRM.Application.Features.Departments.Queries.GetDepartment
{
    public class GetDepartmentQuery : IRequest<DepartmentDto>
    {
        public int Id { get; set; }
    }
}
