using GoSport.Data.Common.Models;
using GoSport.Data.Common.Repository;
using GoSport.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSport.Data.DataSeed
{
    public class DataSeeder
    {
        private ApplicationDbContext db;
        private UserManager<User> userManager;
        
        public DataSeeder(ApplicationDbContext db)
        {
            this.db = db;
            this.userManager = new UserManager<User>(new UserStore<User>(db));
        }

        public void SeedRoles()
        {
            db.Roles.Add(new IdentityRole { Name = "Admin" });
        }


        public  void SeedCategories()
        {
            this.db.SportCategories.Add(new SportCategory() { Name = "Fitness" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Boxing" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Street Fitness" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Crossfit" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Football" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Basketball" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Taekwondo" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Karate" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Volleyball" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Swimming" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Table tennis" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Tae-Bo" });
            this.db.SportCategories.Add(new SportCategory() { Name = "American football" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Zumba" });
            this.db.SportCategories.Add(new SportCategory() { Name = "Bulgarian horo" });
        }

        public void SeedAddresses()
        {
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Center" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Liulin 9" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Drujba 1" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Drujba 2" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Mladost 2" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Mladost 1" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Mladost 3" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Mladost 4" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Ivan Vazov" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Geo Milev" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Pavlovo" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Krasno selo" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Krasna polqna" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Borovo" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Bukston" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Slatina" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighborhood = "Dragalevci" });

            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighborhood = "Center" });
            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighborhood = "Mladost" });
            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighborhood = "Iztok" });
            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighborhood = "Zapad" });

            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighborhood = "Hristo Botev" });
            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighborhood = "Trakiq" });
            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighborhood = "Izgrev" });
            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighborhood = "Stolipinovo" });
        }
    }
}
