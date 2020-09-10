using Balloon.Entities;
using Microsoft.EntityFrameworkCore;

namespace Balloon.Database
{
    public class BalloonDbContext: DbContext
    {
        public BalloonDbContext(DbContextOptions<BalloonDbContext> options):base(options){}
        
        public DbSet<Param> Params { get; set; }
        
    }
}