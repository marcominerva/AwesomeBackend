using AwesomeBackend.Authentication;
using AwesomeBackend.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeBackend.DataAccessLayer
{
    public class ApplicationDbContext : AuthenticationDbContext, IApplicationDbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.OwnsOne(e => e.Address);
            });

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<T> GetData<T>(bool trackingChanges = false) where T : class
        {
            var set = Set<T>();
            if (trackingChanges)
            {
                return set.AsTracking();
            }

            return set.AsNoTracking();
        }

        public void Insert<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        void IApplicationDbContext.Update<T>(T entity)
        {
        }

        public void Delete<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        public Task SaveAsync()
        {
            return SaveChangesAsync();
        }
    }
}
