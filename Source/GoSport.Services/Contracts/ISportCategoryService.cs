using GoSport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSport.Services.Contracts
{
    public interface ISportCategoryService
    {
        IQueryable<string> AllNames();

        IQueryable<SportCategory> All();

        SportCategory Create(string name);

        bool UpdateById(int id, string name);

        bool DeleteById(int id);

        void AddCategoriesForUser(string[] categories, string userId);
    }
}
