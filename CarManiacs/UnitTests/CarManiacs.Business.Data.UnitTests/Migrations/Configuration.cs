﻿using NUnit.Framework;
using System.Data.Entity.Migrations;

namespace CarManiacs.Business.Data.UnitTests.Migrations
{
    [TestFixture]
    public class Configuration
    {
        [Test]
        public void Constructor_ShouldCreateObjectOfTypeDbMigrationsConfiguration()
        {
            //Arange && Act
            var configuration = new Data.Migrations.Configuration();

            //Assert
            Assert.IsInstanceOf<DbMigrationsConfiguration<Data.CarManiacsDbContext>>(configuration);
        }
    }
}
