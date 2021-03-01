using PersonDataCollection.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PersonDataCollection.DAL
{
    public class PersonContext : DbContext, IContext
    {
        public PersonContext() : base("PersonDb")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Client>()
                .HasOptional(c => c.Address)
                .WithRequired(a => a.Client);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}