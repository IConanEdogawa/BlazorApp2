using MediatR;
using TimerService.API.Models;

namespace TimerService.API.UseCases.Commands
{
    public class RemoveGivenTimeCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
