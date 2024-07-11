using Microsoft.EntityFrameworkCore;
using TimerService.API.Models;

namespace TimerService.API.Abstractions
{
    public interface IAppDbContext
    {
        public DbSet<TimerList> TimerLists { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
