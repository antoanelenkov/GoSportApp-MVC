using GoSport.Data.Common.Repository;
using GoSport.Data.Models;
using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSport.Services
{
    public class AddressService : IAddressService
    {
        private IDeletableEntityRepository<Address> addressesDb;

        public AddressService(IDeletableEntityRepository<Address> addressesDb)
        {
            this.addressesDb = addressesDb;
        }

        public IQueryable<Address> All()
        {
            return this
                .addressesDb.All()
                .GroupBy(x=>x.City)
                .Select(x=>x.FirstOrDefault());
        }

        public IQueryable<Address> GetByCity(string cityName)
        {
            return this.addressesDb
                .All()
                .Where(x=>x.City==cityName);
        }
    }
}
