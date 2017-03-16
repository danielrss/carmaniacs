using CarManiacs.Business.Models.Locations;

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
                var bulgaria = new Country();
                bulgaria.Name = "Bulgaria";

                var germany = new Country();
                germany.Name = "Germany";

                var england = new Country();
                england.Name = "England";

                var vt = new City();
                vt.Name = "Veliko Tarnovo";
                vt.Country = bulgaria;
                context.Cities.Add(vt);

                var sofia = new City();
                sofia.Name = "Sofia";
                sofia.Country = bulgaria;
                context.Cities.Add(sofia);

                var ruse = new City();
                ruse.Name = "Ruse";
                ruse.Country = bulgaria;
                context.Cities.Add(ruse);

                var varna = new City();
                varna.Name = "Varna";
                varna.Country = bulgaria;
                context.Cities.Add(varna);

                var stzagora = new City();
                stzagora.Name = "Stara Zagora";
                stzagora.Country = bulgaria;
                context.Cities.Add(stzagora);

                var aachen = new City();
                aachen.Name = "Aachen";
                aachen.Country = germany;
                context.Cities.Add(aachen);

                var munich = new City();
                munich.Name = "Munich";
                munich.Country = germany;
                context.Cities.Add(munich);

                var cologne = new City();
                cologne.Name = "Cologne";
                cologne.Country = germany;
                context.Cities.Add(cologne);

                context.SaveChanges();
            }
        }
    }
}
