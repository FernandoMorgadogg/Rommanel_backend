using Microsoft.AspNetCore.Mvc;
using MediatR;
using Rommanel.API.Models.Messages;

namespace Rommanel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        { 
            return Ok(await _mediator.Send(new GetClientRequest())); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddClientRequest request) 
        {
            var result = await _mediator.Send(request);

            if (result)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateClientRequest request) 
        {
            var result = await _mediator.Send(request);

            if (result)
                return Ok(result);

            return NotFound(result);
        }

        [HttpDelete]    
        public async Task<IActionResult> Delete(DeleteClientRequest request) 
        {
            var result = await _mediator.Send(request);

            if (result)
                return Ok(result);

            return NotFound(result);
        }

    }
}
