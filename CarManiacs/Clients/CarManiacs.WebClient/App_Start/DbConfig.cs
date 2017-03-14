using CarManiacs.Business.Data;
using CarManiacs.Business.Data.Migrations;
using System.Data.Entity;

namespace CarManiacs.WebClient.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarManiacsDbContext, Configuration>());
            CarManiacsDbContext.Create().Database.Initialize(true);
        }
    }
}