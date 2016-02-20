using GoSport.Client.Infrastructure.Mapping;
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
            var model = sportCenterService.All()
                .OrderByDescending(x=>x.CreatedOn)
                .Skip(id * (int)ViewBag.ItemsPerPage)
                .Take((int)ViewBag.ItemsPerPage)
                .To<SportCenterViewModel>()
                .ToList();

            return View(model);
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}