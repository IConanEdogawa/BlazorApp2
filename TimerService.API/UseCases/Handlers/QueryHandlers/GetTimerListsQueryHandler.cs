using MediatR;
using Microsoft.EntityFrameworkCore;
using TimerService.API.Abstractions;
using TimerService.API.Models;
using TimerService.API.UseCases.Queries;

namespace TimerService.API.UseCases.Handlers.QueryHandlers
{
    public class GetTimerListsQueryHandler : IRequestHandler<GetTimerListsQuery, List<TimerList>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetTimerListsQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<TimerList>> Handle(GetTimerListsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var timeList = await _appDbContext.TimerLists.ToListAsync(cancellationToken);


                return timeList;
            }
            catch (Exception ex)
            {

                return null!;
            }
        }
    }
}
