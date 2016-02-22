﻿using GoSport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoSport.Services.Contracts
{
    public interface ISportCenterService
    {
        SportCenter GetById(int id);

        IQueryable<SportCenter> All();

        SportCenter Create(SportCenter model);

        void AddImagesToSportCenter(string sportCenterName,IEnumerable<string> imagesUrl);

        void AddCommentToSportCenter(int sportCenterId,string authorId,string content);

        double AddRatingToSportCenter(int sportCenterId,string userId, string ratingType, int value);

        IQueryable<string> GetImagesForSportCenter(string sportCenterName);

        bool UpdateById(int id, string name);

        bool DeleteById(int id);
    }
}
