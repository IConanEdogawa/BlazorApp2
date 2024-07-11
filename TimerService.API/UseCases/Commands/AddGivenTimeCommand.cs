using MediatR;
using TimerService.API.Models;

namespace TimerService.API.UseCases.Commands
{
    public class AddGivenTimeCommand : IRequest<ResponseModel>
    {
        public string Given { get; set; }
        public string When { get; set; }
        public string Then { get; set; }
    }
}
