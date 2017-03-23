using CarManiacs.Business.Models.Locations;

using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CarManiacs.Business.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CarManiacsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CarManiacsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (!context.Cities.Any() && !context.Countries.Any())
            {
                var bulgaria = new Country() { Id = Guid.NewGuid() };
                bulgaria.Name = "Bulgaria";

                var germany = new Country() { Id = Guid.NewGuid() };
                germany.Name = "Germany";

                var england = new Country() { Id = Guid.NewGuid() };
                england.Name = "England";

                var vt = new City() { Id = Guid.NewGuid() };
                vt.Name = "Veliko Tarnovo";
                vt.Country = bulgaria;
                context.Cities.Add(vt);

                var sofia = new City() { Id = Guid.NewGuid() };
                sofia.Name = "Sofia";
                sofia.Country = bulgaria;
                context.Cities.Add(sofia);

                var ruse = new City() { Id = Guid.NewGuid() };
                ruse.Name = "Ruse";
                ruse.Country = bulgaria;
                context.Cities.Add(ruse);

                var varna = new City() { Id = Guid.NewGuid() };
                varna.Name = "Varna";
                varna.Country = bulgaria;
                context.Cities.Add(varna);

                var stzagora = new City() { Id = Guid.NewGuid() };
                stzagora.Name = "Stara Zagora";
                stzagora.Country = bulgaria;
                context.Cities.Add(stzagora);

                var aachen = new City() { Id = Guid.NewGuid() };
                aachen.Name = "Aachen";
                aachen.Country = germany;
                context.Cities.Add(aachen);

                var munich = new City() { Id = Guid.NewGuid() };
                munich.Name = "Munich";
                munich.Country = germany;
                context.Cities.Add(munich);

                var cologne = new City() { Id = Guid.NewGuid() };
                cologne.Name = "Cologne";
                cologne.Country = germany;
                context.Cities.Add(cologne);

                context.SaveChanges();
            }
        }
    }
}
