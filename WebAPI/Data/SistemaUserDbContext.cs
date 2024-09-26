using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Map;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SistemaUserDbContext : DbContext
    {
        public SistemaUserDbContext(DbContextOptions<SistemaUserDbContext> options) 
            : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }


}
