using GoSport.Client.Areas.Administration.ViewModels;
using GoSport.Client.Infrastructure.Mapping;
using GoSport.Data.Models;
using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GoSport.Client.Areas.Administration.Controllers
{
    public class AddressesController:AdminController
    {
        public AddressesController(
           ISportCategoryService sportCategories,
           IAddressService addressService,
           ISportCategoryService categoryService,
           ISportCenterService sportCenterService)
            : base(sportCategories, addressService, categoryService, sportCenterService)
        {

        }

        public ActionResult Index()
        {
            var model = addressService
                .All()
                .OrderBy(x => x.City)
                .To<AdminAddressViewModel>()
                .ToList();

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sportCenter = this.sportCategories.GetById((int)id);
            if (sportCenter == null)
            {
                return HttpNotFound();
            }

            return View(sportCenter);
        }

        [HttpPost]
        public ActionResult Edit(AdminSportCenterViewModel sportCenter)
        {
            if (ModelState.IsValid)
            {
                this.sportCenterService.Update(Mapper.Map<SportCenter>(sportCenter), sportCenter.City, sportCenter.Neighbour);

                return RedirectToAction("Index");
            }

            return View(sportCenter);
        }

        // GET: Administration/SportCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var isDeleted = this.sportCenterService.DeleteById((int)id);

            if (!isDeleted)
            {
                return HttpNotFound();
            }

            return View();
        }
    }
}