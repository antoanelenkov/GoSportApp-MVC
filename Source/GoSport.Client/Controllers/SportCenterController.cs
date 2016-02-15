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
    public class SportCenterController : Controller
    {
        ISportCenterService sportCenters;

        public SportCenterController(ISportCenterService sportCenters)
        {
            this.sportCenters = sportCenters;
        }

        public ActionResult SportCenters()
        {
            var all = sportCenters.All().To<SportCenterViewModel>().ToList();

            Response.Write("All sport centers are: " + all.Count());
            return View();
        }
    }
}