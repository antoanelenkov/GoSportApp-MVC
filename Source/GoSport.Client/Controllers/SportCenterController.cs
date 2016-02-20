using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoSport.Client.ViewModels.SportCenters;
using GoSport.Client.Infrastructure.Mapping;

namespace GoSport.Client.Controllers
{
    public class SportCenterController : BaseController
    {
        ISportCenterService sportCenters;

        public SportCenterController(ISportCategoryService sportCategories, IAddressService addressService, ISportCategoryService categoryService)
            :base(sportCategories,addressService,categoryService)
        { }

        public ActionResult SportCenters()
        {
            var all = sportCenters.All().To<SportCenterViewModel>().ToList();

            Response.Write("All sport centers are: " + all.Count());
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddSportCenterViewModel model)
        {
            return View();
        }
    }
}