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
            model.Rating = new SportCenterRating();
            this.sportCentersDb.Add(model);
            this.sportCentersDb.SaveChanges();

            return model;
        }

        public bool DeleteById(int id)
        {
            var entity = sportCentersDb.All().FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }

            sportCentersDb.Delete(id);
            sportCentersDb.SaveChanges();

            return true;
        }

        public void AddCommentToSportCenter(int sportCenterId, string authorId, string content)
        {
            var sportCenter = sportCentersDb.All().FirstOrDefault(x => x.Id == sportCenterId);
            var user = usersDb.All().FirstOrDefault(x => x.Id == authorId);
            sportCenter.Comments.Add(new Comment() { SportCenterId = sportCenterId, Content = content, Author= user });
            sportCentersDb.SaveChanges();
        }

        public double AddRatingToSportCenter(int sportCenterId,string authorId, string ratingType, int value)
        {
            var sportCenter = sportCentersDb.All().FirstOrDefault(x => x.Id == sportCenterId);
            var user = usersDb.All().FirstOrDefault(x => x.Id == authorId);

            if (ratingType == "Comfort")
            {
                sportCenter.Rating.Comfort = (sportCenter.Rating.Comfort * sportCenter.Rating.ComfortVotes + value) / ++sportCenter.Rating.ComfortVotes;
                sportCentersDb.SaveChanges();
                return sportCenter.Rating.Comfort;
            }
            else if (ratingType == "Trainers")
            {
                sportCenter.Rating.Trainers = (sportCenter.Rating.Trainers * sportCenter.Rating.TrainersVotes + value) / ++sportCenter.Rating.TrainersVotes;       
                sportCentersDb.SaveChanges();
                return sportCenter.Rating.Trainers;
            }
            else if (ratingType == "Price")
            {
                sportCenter.Rating.Price = (sportCenter.Rating.Price * sportCenter.Rating.PriceVotes + value) / ++sportCenter.Rating.PriceVotes;
                sportCentersDb.SaveChanges();
                return sportCenter.Rating.Price;
            }
            else if (ratingType == "Service")
            {
                sportCenter.Rating.Service = (sportCenter.Rating.Service * sportCenter.Rating.ServiceVotes + value) / ++sportCenter.Rating.ServiceVotes;
                sportCentersDb.SaveChanges();
                return sportCenter.Rating.Service;
            }
            else if (ratingType == "Total")
            {
                sportCenter.Rating.Total = (sportCenter.Rating.Total * sportCenter.Rating.TotalVotes + value) / ++sportCenter.Rating.TotalVotes;
                sportCentersDb.SaveChanges();
                return sportCenter.Rating.Total;
            }

            throw new ArgumentException("invalid type provided");
        }
    }
}
