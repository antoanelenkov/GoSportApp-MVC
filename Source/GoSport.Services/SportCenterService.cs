using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoSport.Data.Common.Repository;
using GoSport.Data.Models;

namespace GoSport.Services
{
    public class SportCenterService : ISportCenterService
    {
        private IDeletableEntityRepository<SportCenter> sportCentersDb;

        public SportCenterService(IDeletableEntityRepository<SportCenter> sportCentersDb)
        {
            this.sportCentersDb = sportCentersDb;
        }

        public IEnumerable<SportCenter> All()
        {
            return this.sportCentersDb.All();
        }

        public SportCenter Create(SportCenter model)
        {
            this.sportCentersDb.Add(model);

            return model;
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
