using Microsoft.EntityFrameworkCore;
using System.Reflection;
using University_CRM.Domain.Common;
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<AuditEntity>())
            {
                switch(entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.AddEntity();
                        break;
                    case EntityState.Modified:
                        entity.Entity.ModifiedEntity();
                        break;
                    case EntityState.Deleted:
                        entity.Entity.DeletedEntity();
                        entity.State= EntityState.Modified;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
