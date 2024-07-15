using MediatR;
using TimerService.API.Abstractions;
using TimerService.API.Models;
using TimerService.API.UseCases.Commands;

namespace TimerService.API.UseCases.Handlers.CommandHandlers
{
    public class RemoveGivenTimeCommandHandler : IRequestHandler<RemoveGivenTimeCommand, ResponseModel>
    {
        private readonly IAppDbContext _appDbContext;

        public RemoveGivenTimeCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseModel> Handle(RemoveGivenTimeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var timerToDelete = await _appDbContext.TimerLists.FindAsync(request.Id);

                if (timerToDelete == null)
                {
                    return new ResponseModel { IsSuccess = false, Message = "Timer record not found.", StatusCode = 404 };
                }

                _appDbContext.TimerLists.Remove(timerToDelete);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel { IsSuccess = true, Message = "Timer record deleted successfully.", StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new ResponseModel { IsSuccess = false, Message = $"Error deleting timer record: {ex.Message}", StatusCode = 500 };
            }
        }
    }

}
