namespace GoSport.Data.Migrations
{
    using GoSport.Data.DataSeed;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
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
            const string AdministratorUserName = "admin@abv.bg";
            const string AdministratorPassword = "qwerty";

            if (context.Roles.Any()) return;

            var dataSeeder = new DataSeeder(context);

            dataSeeder.SeedRoles();
            dataSeeder.SeedCategories();
            dataSeeder.SeedAddresses();

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName };
            userManager.Create(user, AdministratorPassword);

            context.SaveChanges();
        }
    }
}
