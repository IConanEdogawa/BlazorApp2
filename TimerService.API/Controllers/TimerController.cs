using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimerService.API.UseCases.Commands;
using TimerService.API.UseCases.Queries;
using System.Threading.Tasks;

namespace TimerService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddGivenTime(AddGivenTimeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTimerList()
        {
            
            var result = await _mediator.Send(new GetTimerListsQuery());

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGivenTime(RemoveGivenTimeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
