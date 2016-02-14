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
        IEnumerable<SportCenter> All();

        SportCenter Create(SportCenter model);

        bool UpdateById(int id, string name);

        bool DeleteById(int id);
    }
}
