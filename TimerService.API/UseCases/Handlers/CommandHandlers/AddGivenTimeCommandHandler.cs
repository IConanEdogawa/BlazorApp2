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
            var time = new TimerList()
            {
                Id = Guid.NewGuid(),
                Given = request.Given,
                When = request.When,
                Then = request.When
            };

            await _appDbContext.TimerLists.AddAsync(time);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseModel()
            {
                Message = "Timer list added succsessfully !",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
