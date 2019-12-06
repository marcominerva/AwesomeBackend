using System.Linq;
using System.Threading.Tasks;

namespace AwesomeBackend.DataAccessLayer
{
    public interface IApplicationDbContext
    {
        // Retrieve data from a generic table.
        IQueryable<T> GetData<T>(bool trackingChanges = false) where T : class;

        void Insert<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task SaveAsync();
    }
}
