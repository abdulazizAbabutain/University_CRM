using Microsoft.AspNetCore.Mvc;
using University_CRM.Application.Features.Collages.Commands;
using University_CRM.Application.Features.Collages.Queries;

namespace University_CRM.API.Controllers
{
    public class CollageController : ApiController
    { 
        [HttpPost]
        public IActionResult AddCollage(AddCollageCommand command)
        {
           Mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCollageQuery query)
            => Ok(await Mediator.Send(query));
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCollage([FromRoute] int? id)
        {
            if (id is null)
                return BadRequest();
            var collage = await Mediator.Send(new GetCollageQuery() { Id = id.Value });
            return Ok(collage);
        }
    }
}
