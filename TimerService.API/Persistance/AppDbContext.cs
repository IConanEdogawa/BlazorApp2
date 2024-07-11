using Microsoft.EntityFrameworkCore;
using TimerService.API.Abstractions;
using TimerService.API.Models;

namespace TimerService.API.Persistance
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TimerList> TimerLists { get; set; }
    }
}
