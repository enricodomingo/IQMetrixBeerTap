using System.Data.Entity.ModelConfiguration.Conventions;

namespace BeerTap.Facade.Model
{
    using System.Data.Entity;

    public partial class BeerTap : DbContext
    {
        public BeerTap()
            : base("name=BeerTap")
        {

        }

        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            
        }
    }
}
