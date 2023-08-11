using Microsoft.EntityFrameworkCore;

namespace Core_Deneme.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Kullanicilar>Kullanicilar { get; set; }
    }
}
