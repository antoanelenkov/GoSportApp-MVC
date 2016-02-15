using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSport.Services.Contracts
{
    public interface IAddressService
    {
        IQueryable<string> AllCities();

        IQueryable<string> AllNeighbourhoodsInCity(string cityName);
    }
}
