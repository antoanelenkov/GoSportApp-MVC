using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoSport.Data.Models;
using GoSport.Data.Common.Repository;

namespace GoSport.Services
{
    public class SportCategoryService : ISportCategoryService
    {
        private IDeletableEntityRepository<SportCategory> sportCategoriesDb;
        private IDeletableEntityRepository<User> usersDb;
        private IDeletableEntityRepository<SportCenter> sportCentesDb;

        public SportCategoryService(
            IDeletableEntityRepository<SportCategory> sportCategoriesDb, 
            IDeletableEntityRepository<User> usersDb,
            IDeletableEntityRepository<SportCenter> sportCentesDb)
        {
            this.sportCategoriesDb = sportCategoriesDb;
            this.usersDb = usersDb;
            this.sportCentesDb =  sportCentesDb;
        }

        public void AddCategoriesForSportCenter(IEnumerable<string> categoriesNames, string sportCenterName)
        {
            var sportCenter = sportCentesDb.All().FirstOrDefault(x => x.Name == sportCenterName);

            foreach (var name in categoriesNames)
            {
                var currentCategory = this.sportCategoriesDb.All().FirstOrDefault(x => x.Name == name);

                if (currentCategory != null)
                {
                    currentCategory.SportCenters.Add(sportCenter);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(name)) continue;
                    sportCategoriesDb.Add(new SportCategory() { Name = name.Trim(), SportCenters = new List<SportCenter>() { sportCenter } });
                }
            }
            sportCategoriesDb.SaveChanges();
        }

        public void AddCategoriesForUser(IEnumerable<string> categories, string userId)
        {
            var user = usersDb.All().FirstOrDefault(x => x.Id == userId);

            foreach (var name in categories)
            {
                var currentCategory = this.sportCategoriesDb.All().FirstOrDefault(x => x.Name == name);

                if (currentCategory != null)
                {
                    currentCategory.Users.Add(user);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(name)) continue;
                    sportCategoriesDb.Add(new SportCategory() { Name = name, Users = new List<User>() { user } });
                }
            }

            sportCategoriesDb.SaveChanges();
        }

        public IQueryable<SportCategory> All()
        {
            return sportCategoriesDb.All();
        }

        public IQueryable<string> AllNames()
        {
            return sportCategoriesDb.All().Select(x => x.Name);
        }

        public SportCategory Create(string name)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            var entity = sportCategoriesDb.All().FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            sportCategoriesDb.Delete(id);
            sportCategoriesDb.SaveChanges();

            return true;
        }

        public IQueryable<SportCenter> GetByCategories(IEnumerable<string> categoriesNames)
        {
            var fromCategories = new List<SportCenter>();

            foreach (var category in categoriesNames)
            {
                fromCategories = sportCategoriesDb.All()
                    .FirstOrDefault(x => x.Name == category)
                    .SportCenters.ToList();
            }

            return fromCategories.AsQueryable();
        }

        public bool UpdateById(int id, string name)
        {
            throw new NotImplementedException();
        }

        public SportCategory GetById(int id)
        {
            return sportCategoriesDb.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
