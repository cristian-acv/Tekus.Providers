using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tekus.Providers.Application.Features.Providers.Commands.CreateProvider;
using Tekus.Providers.Application.Features.Providers.Commands.DeleteProvider;
using Tekus.Providers.Application.Features.Providers.Commands.UpdateProvider;

namespace Tekus.Providers.Api.Controllers
{
    public class ProviderController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Create([FromBody] CreateProviderCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(int id,[FromBody] UpdateProviderCommand command)
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
            await Mediator.Send(new DeleteProviderCommand { Id = id });

            return NoContent();
        }
    }
}
