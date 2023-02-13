using Microsoft.AspNetCore.Mvc;
using University_CRM.Application.Features.Departments.Commands.AddDepaertment;
using University_CRM.Application.Features.Departments.Queries.GetAllDepartments;
using University_CRM.Application.Features.Departments.Queries.GetDepartment;

namespace University_CRM.API.Controllers
{
    public class DepartmentController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentCommand command)
        {
            await Mediator.Send(command);
            return Ok(); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartment([FromQuery] GetAllDepartmentsQuery query)
            =>  Ok(await Mediator.Send(query));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDepartment([FromRoute]int? id)
        {
            if (id is null)
                return BadRequest();
            return Ok(await Mediator.Send(new GetDepartmentQuery { Id = id.Value} ));
        }
         


    }
}
