using GoSport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSport.Services.Contracts
{
    public interface ISportCenterService
    {
        IQueryable<SportCenter> All();

        SportCenter Create(SportCenter model);

        void AddImagesToSportCenter(string sportCenterName,IEnumerable<string> imagesUrl);

        IQueryable<string> GetImagesForSportCenter(string sportCenterName);

        bool UpdateById(int id, string name);

        bool DeleteById(int id);
    }
}
