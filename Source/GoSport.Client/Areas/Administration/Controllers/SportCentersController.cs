using GoSport.Client.Infrastructure.Mapping;
using GoSport.Client.ViewModels.SportCenters;
using GoSport.Data.Models;
using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GoSport.Client.Areas.Administration.Controllers
{
    public class SportCentersController : AdminController
    {
        public SportCentersController(
            ISportCategoryService sportCategories,
            IAddressService addressService,
            ISportCategoryService categoryService,
            ISportCenterService sportCenterService)
            : base(sportCategories, addressService, categoryService, sportCenterService)
        {
        }

        public ActionResult Index()
        {
            var model = sportCenterService
                .All()
                .To<AdminSportCenterViewModel>()
                .ToList();

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var entity = this.sportCategories.All().FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(Mapper.Map<AdminSportCenterViewModel>(entity));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sportCenter = this.sportCategories.All().FirstOrDefault(x => x.Id == id);
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
                var entity = this.sportCenterService.All().FirstOrDefault(x => x.Id == sportCenter.Id);

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

        //// POST: Administration/Comments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    this.Data.Comments.Delete(id);
        //    this.Data.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        this.Data.Context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
