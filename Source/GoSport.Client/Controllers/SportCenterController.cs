using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var all = sportCenters.All().Count();

            Response.Write("All sport centers are: " + all);
            return View();
        }
    }
}