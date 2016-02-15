using GoSport.Data.Common.Models;
using GoSport.Data.Common.Repository;
using GoSport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSport.Data.DataSeed
{
    public class DataSeeder
    {
        ApplicationDbContext db;
        
        public DataSeeder(ApplicationDbContext db)
        {
            this.db = db;
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
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Center" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Liulin 9" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Drujba 1" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Drujba 2" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Mladost 2" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Mladost 1" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Mladost 3" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Mladost 4" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Ivan Vazov" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Geo Milev" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Pavlovo" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Krasno selo" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Krasna polqna" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Borovo" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Bukston" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Slatina" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Dragalevci" });

            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighbourhood = "Center" });
            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighbourhood = "Mladost" });
            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighbourhood = "Iztok" });
            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighbourhood = "Zapad" });

            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighbourhood = "Hristo Botev" });
            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighbourhood = "Trakiq" });
            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighbourhood = "Izgrev" });
            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighbourhood = "Stolipinovo" });
        }

        public void SeedAddresses()
        {
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Center" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Liulin 9" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Drujba 1" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Drujba 2" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Mladost 2" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Mladost 1" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Mladost 3" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Mladost 4" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Ivan Vazov" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Geo Milev" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Pavlovo" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Krasno selo" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Krasna polqna" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Borovo" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Bukston" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Slatina" });
            this.db.Addresses.Add(new Address() { City = "Sofia", Neighbourhood = "Dragalevci" });

            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighbourhood = "Center" });
            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighbourhood = "Mladost" });
            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighbourhood = "Iztok" });
            this.db.Addresses.Add(new Address() { City = "Pazardzhik", Neighbourhood = "Zapad" });

            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighbourhood = "Hristo Botev" });
            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighbourhood = "Trakiq" });
            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighbourhood = "Izgrev" });
            this.db.Addresses.Add(new Address() { City = "Plovdiv", Neighbourhood = "Stolipinovo" });
        }


    }
}
