using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tekus.Providers.Application.Features.Providers.Commands.CreateProvider;
using Tekus.Providers.Application.Features.Providers.Commands.DeleteProvider;
using Tekus.Providers.Application.Features.Providers.Commands.UpdateProvider;
using Tekus.Providers.Application.Features.Providers.Queries.GetProviders;

namespace Tekus.Providers.Api.Controllers
{
    public class ProviderController : ApiControllerBase
    {
       
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(PaginatedList <ProviderVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginatedList<ProviderVm>>> GetProviders([FromQuery] GetProvidersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Create([FromBody] CreateProviderCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize]
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
        [Authorize]
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
