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

        public SportCategoryService(IDeletableEntityRepository<SportCategory> sportCategoriesDb, IDeletableEntityRepository<User> usersDb)
        {
            this.sportCategoriesDb = sportCategoriesDb;
            this.usersDb = usersDb;
        }

        public IQueryable<SportCategory> All()
        {
            return sportCategoriesDb.All();
        }

        public IQueryable<string> AllNames()
        {
            return sportCategoriesDb.All().Select(x => x.Name);
        }

        public void AddCategoriesForUser(string[] categories, string userId)
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
                    sportCategoriesDb.Add(new SportCategory() { Name = name, Users = new List<User>() { user } });
                }
            }
        }

        public SportCategory Create(string name)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateById(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
