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
        private IDeletableEntityRepository<User> usersDb;

        public SportCenterService(IDeletableEntityRepository<SportCenter> sportCentersDb, IDeletableEntityRepository<User> usersDb)
        {
            this.sportCentersDb = sportCentersDb;
            this.usersDb = usersDb;
        }

        public void AddImagesToSportCenter(string sportCenterName, IEnumerable<string> imagesUrl)
        {
            var sportCenter = sportCentersDb.All().FirstOrDefault(x => x.Name == sportCenterName);
            var urls = new StringBuilder();

            foreach (var imgUrl in imagesUrl)
            {
                urls.Append("," + imgUrl);
            }
            sportCenter.PicturesUrls= urls.ToString();

            sportCentersDb.SaveChanges();
        }

        public IQueryable<string> GetImagesForSportCenter(string sportCenterName)
        {
            var sportCenter = sportCentersDb.All().FirstOrDefault(x => x.Name == sportCenterName);

            var urlsAsString = sportCenter.PicturesUrls;
            if (urlsAsString != null)
            {
                return urlsAsString
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .AsQueryable();
            }

            return new List<string>().AsQueryable();
        }

        public bool UpdateById(int id, string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SportCenter> All()
        {
            return this.sportCentersDb.All();
        }

        public SportCenter Create(SportCenter model)
        {
            this.sportCentersDb.Add(model);
            this.sportCentersDb.SaveChanges();

            return model;
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddCommentToSportCenter(int sportCenterId, string authorId, string content)
        {
            var sportCenter = sportCentersDb.All().FirstOrDefault(x => x.Id == sportCenterId);
            var user = usersDb.All().FirstOrDefault(x => x.Id == authorId);
            sportCenter.Comments.Add(new Comment() { SportCenterId = sportCenterId, Content = content, Author= user });
            sportCentersDb.SaveChanges();
        }
    }
}
