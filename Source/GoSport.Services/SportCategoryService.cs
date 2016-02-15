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

        public SportCategoryService(IDeletableEntityRepository<SportCategory> sportCategoriesDb)
        {
            this.sportCategoriesDb = sportCategoriesDb;
        }

        public IQueryable<string> AllNames()
        {
            return sportCategoriesDb.All().Select(x=>x.Name);
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
