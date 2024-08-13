using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SkateShop.Domain.Entities;
using SkateShop.Domain;
using SkateShop.Infrastructure.Mappings;

namespace SkateShop.Infrastructure
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext(
            DbContextOptions<DataContext> options)
            //IHttpContext httpContext)
            : base(options)
        {
            //_httpContext = httpContext;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<MessageBar> Messages { get; set; }

        public virtual async Task CommitAsync()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State is EntityState.Added or EntityState.Modified)
                .Where(e => e.Entity is Entity);

            foreach (var entry in modifiedEntries)
            {
                var entity = (Entity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                    //entity.CreatedBy = _httpContext.GetUserId();
                    entity.CreatedBy = Guid.NewGuid();
                }

                entity.ModifiedAt = DateTime.UtcNow;
                //entity.ModifiedBy = _httpContext.GetUserId();
                entity.ModifiedBy = Guid.NewGuid();
            }

            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageMapping());
        }
    }
}
