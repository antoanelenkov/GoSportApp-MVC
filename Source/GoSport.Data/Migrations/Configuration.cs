namespace GoSport.Data.Migrations
{
    using GoSport.Data.DataSeed;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GoSport.Data.ApplicationDbContext context)
        {
            if (context.Roles.Any()) return;

            var dataSeeder = new DataSeeder(context);

            dataSeeder.SeedRoles();
            dataSeeder.SeedCategories();
            dataSeeder.SeedAddresses();
            context.SaveChanges();
        }
    }
}
