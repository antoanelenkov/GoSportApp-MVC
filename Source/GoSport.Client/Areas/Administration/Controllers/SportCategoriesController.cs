namespace TicketingSystem.Web.Areas.Administration.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using GoSport.Services.Contracts;
    using GoSport.Client.Infrastructure.Mapping;
    using GoSport.Data.Models;
    using GoSport.Client.Areas.Administration.Controllers;
    using GoSport.Client.Areas.Administration.ViewModels;
    using System.Net;

    public class SportCategoriesController : AdminController
    {
        public SportCategoriesController(
            ISportCategoryService sportCategories,
            IAddressService addressService,
            ISportCategoryService categoryService,
            ISportCenterService sportCenterService)
            : base(sportCategories, addressService, categoryService, sportCenterService)
        {
        }

        public ActionResult Index()
        {
            var model = sportCategories
                .All()
                .OrderByDescending(x => x.CreatedOn)
                .To<AdminSportCategoryViewModel>()
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

        //[HttpPost]
        //public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        //{
        //    if (model != null && ModelState.IsValid)
        //    {
        //        var category = this.Data.Categories.GetById(model.Id.Value);

        //        foreach (var ticketId in category.Tickets.Select(t => t.Id).ToList())
        //        {
        //            var comments = this.Data
        //                .Comments
        //                .All()
        //                .Where(c => c.TicketId == ticketId)
        //                .Select(c => c.Id)
        //                .ToList();

        //            foreach (var commentId in comments)
        //            {
        //                this.Data.Comments.Delete(commentId);
        //            }

        //            this.Data.SaveChanges();

        //            this.Data.Tickets.Delete(ticketId);
        //        }

        //        this.Data.SaveChanges();

        //        this.Data.Categories.Delete(category);
        //        this.Data.SaveChanges();
        //    }

        //    this.ClearCategoryCache();
        //    return this.GridOperation(model, request);
        //}
    }
}