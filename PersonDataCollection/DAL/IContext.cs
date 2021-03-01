using PersonDataCollection.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace PersonDataCollection.DAL
{
    public interface IContext
    {
        DbSet<Person> People { get; set; }
        DbSet<Staff> Staff { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Address> Addresses { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}