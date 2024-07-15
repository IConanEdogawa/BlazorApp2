using MediatR;
using TimerService.API.Abstractions;
using TimerService.API.Models;
using TimerService.API.UseCases.Commands;

namespace TimerService.API.UseCases.Handlers.CommandHandlers
{
    public class AddGivenTimeCommandHandler : IRequestHandler<AddGivenTimeCommand, ResponseModel>
    {
        private readonly IAppDbContext _appDbContext;

        public AddGivenTimeCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseModel> Handle(AddGivenTimeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var time = new TimerList
                {
                    Id = Guid.NewGuid(),
                    Given = request.Given,
                    When = request.When,
                    Then = request.Then
                };

                await _appDbContext.TimerLists.AddAsync(time, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);



                return new ResponseModel
                {
                    Message = "Timer list added successfully!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {

                return new ResponseModel
                {
                    Message = "Failed to add timer list.",
                    StatusCode = 500,
                    IsSuccess = false
                };
            }
        }
    }
}
