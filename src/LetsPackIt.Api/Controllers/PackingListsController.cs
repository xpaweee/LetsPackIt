using System.Collections.Generic;
using System.Threading.Tasks;
using LetsPackIt.Application.Commands;
using LetsPackIt.Application.DTO;
using LetsPackIt.Application.Queries;
using LetsPackIt.Shared.Abstractions.Commands;
using LetsPackIt.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LetsPackIt.Api.Controllers
{
  
    public class PackingListsController : BaseController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public PackingListsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PackingListDto>> Get([FromRoute] GetPackingList query)
        {
            var result = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }  
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackingListDto>>> Get([FromQuery] SearchPackingLists query)
        {
            var result = await _queryDispatcher.QueryAsync(query);

            return OkOrNotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePackingListWithItems command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }
        
        [HttpPut("{packingListId}/items")]
        public async Task<IActionResult> Put([FromBody] AddPackingItem  command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        } 
        
        [HttpPut("{packingListId:guid}/items/{name}/pack")]
        public async Task<IActionResult> Put([FromBody] PackItem  command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }
        
        [HttpDelete("{packingListId:guid}/items/{name}")]
        public async Task<IActionResult> Delete([FromBody] RemovePackingItem  command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }   
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromBody] RemovePackingList  command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok();
        }
    }
}