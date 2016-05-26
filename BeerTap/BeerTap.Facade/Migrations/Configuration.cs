using BeerTap.Facade.Model;

namespace BeerTap.Facade.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeerTap.Facade.Model.BeerTap>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BeerTap.Facade.Model.BeerTap context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Offices.AddOrUpdate(
              o => o.Id,
              new Office { Description = "Manila, Philippines", Name = "Manila" },
              new Office { Description = "Vancouver, Canada", Name = "Vancouver" }
            );

            context.Beers.AddOrUpdate(
                  b => b.Id,
                  new Beer { Name = "San Miguel Beer", Container = 500, mL = 500, OfficeId = 1},
                  new Beer { Name = "Red Horse", Container = 500, mL = 500, OfficeId = 1 },
                  new Beer { Name = "San Mig Apple", Container = 500, mL = 500, OfficeId = 2 }
                );

            context.Employees.AddOrUpdate(
                  e => e.Id,
                  new Employee { Name = "Enrico Domingo", OfficeId = 1 },
                  new Employee { Name = "John Paul Asuncion", OfficeId = 1 },
                  new Employee { Name = "John Evans Andal", OfficeId = 2 }
                );
        }
    }
}
