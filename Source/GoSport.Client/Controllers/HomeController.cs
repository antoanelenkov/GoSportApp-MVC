﻿using GoSport.Client.Infrastructure.Mapping;
using GoSport.Client.ViewModels.SportCenters;
using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoSport.Client.Controllers
{
    public class HomeController : BaseController
    {
        private ISportCenterService sportCenterService;

        public HomeController(
            ISportCategoryService sportCategories,
            IAddressService addressService,
            ISportCategoryService categoryService,
            ISportCenterService sportCenterService)
            : base(sportCategories, addressService, categoryService)
        {
            this.sportCenterService = sportCenterService;

            ViewBag.AllSportCentersCount = sportCenterService.All().Count();
            ViewBag.ItemsPerPage = 2;
        }

        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            if (id < 0) id = 0;
            if (id > 0)id = id - 1; 

            var model = sportCenterService.All()
                .OrderByDescending(x=>x.CreatedOn)
                .Skip(id * (int)ViewBag.ItemsPerPage)
                .Take((int)ViewBag.ItemsPerPage)
                .To<SportCenterViewModel>()
                .ToList();

            foreach (var sportCenter in model)
            {
                sportCenter.Images = SanitizeImageUrls(sportCenterService.GetImagesForSportCenter(sportCenter.Name).ToArray());
            }

            return View(model);
        }

        //[HttpGet]
        //public ActionResult SportCentersByCategory(string category)
        //{
        //    var model = sportCategories.All()
        //        .Where(x=>x.Name==category)
        //        .Select(x=>x.SportCenters)
        //        .Take((int)ViewBag.ItemsPerPage)
        //        .To<SportCenterViewModel>()
        //        .ToList();

        //    foreach (var sportCenter in model)
        //    {
        //        sportCenter.Images = SanitizeImageUrls(sportCenterService.GetImagesForSportCenter(sportCenter.Name).ToArray());
        //    }

        //    return View(model);
        //}


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        private ICollection<string> SanitizeImageUrls(string[] urls)
        {
            for (int i = 0; i < urls.Count(); i++)
            {
                var startPoint = urls[i].IndexOf("Content");
                urls[i] = urls[i].Substring(startPoint - 1);
            }

            return urls;
        }
    }
}