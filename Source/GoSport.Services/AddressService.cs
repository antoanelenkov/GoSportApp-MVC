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
        private IDeletableEntityRepository<User> usersDb;

        public AddressService(IDeletableEntityRepository<Address> addressesDb, IDeletableEntityRepository<User> usersDb)
        {
            this.addressesDb = addressesDb;
            this.usersDb = usersDb;
        }

        public IQueryable<Address> AllCities()
        {
            return this
                .addressesDb.All()
                .GroupBy(x => x.City)
                .Select(x => x.FirstOrDefault());
        }

        public IQueryable<Address> All()
        {
            return this
                .addressesDb.All();
        }

        public IQueryable<Address> GetByCity(string cityName)
        {
            return this.addressesDb
                .All()
                .Where(x => x.City == cityName);
        }

        public void AddAddressForUser(string userId, int neighbourId)
        {
            var address = addressesDb.All()
                .FirstOrDefault(x => neighbourId == x.Id);

            var user = usersDb.All().FirstOrDefault(x => x.Id == userId);
            user.AddressId = address.Id;

            usersDb.SaveChanges();
        }
    }
}
