using Microsoft.EntityFrameworkCore;
using System.Reflection;
using University_CRM.Domain.Entities;

namespace University_CRM.Infrastructure.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) 
        {

        }
        public DbSet<Collage> Collage => Set<Collage>();
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
