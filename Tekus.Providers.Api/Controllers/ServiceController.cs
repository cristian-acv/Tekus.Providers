using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tekus.Providers.Application.Features.Services.Commands.CreateService;
using Tekus.Providers.Application.Features.Services.Commands.DeleteService;
using Tekus.Providers.Application.Features.Services.Commands.UpdateService;
using Tekus.Providers.Application.Features.Services.Queries.GetServicesList;

namespace Tekus.Providers.Api.Controllers
{
    public class ServiceController :  ApiControllerBase
    {

        [HttpGet("{name}")]
        [ProducesResponseType(typeof(IEnumerable<ServicesVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ServicesVm>>> GeServicesByUsername(string name)
        {
            var query = new GetServiceByNameListQuery(name);
            var services = await Mediator.Send(query);
            return Ok(services);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Create([FromBody] CreateServiceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateServiceCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteServiceCommand { Id = id });

            return NoContent();
        }
    }
}
