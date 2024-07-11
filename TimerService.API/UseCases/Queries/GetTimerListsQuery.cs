using MediatR;
using TimerService.API.Models;

namespace TimerService.API.UseCases.Queries
{
    public class GetTimerListsQuery : IRequest<List<TimerList>>
    {

    }
}
