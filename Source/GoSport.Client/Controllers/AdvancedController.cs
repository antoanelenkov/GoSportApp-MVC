using GoSport.Client.Infrastructure;
using GoSport.Client.Infrastructure.Mapping;
using GoSport.Client.ViewModels.Advanced;
using GoSport.Client.ViewModels.SportCenters;
using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoSport.Client.Controllers
{
    public class AdvancedController : BaseController
    {
        ISportCenterService sportCenterService;

        public AdvancedController(
            ISportCategoryService sportCategories,
            IAddressService addressService,
            ISportCategoryService categoryService,
            ISportCenterService sportCenterService)
            : base(sportCategories, addressService, categoryService)
        {
            this.sportCenterService = sportCenterService;
        }

        [HttpGet]
        public ActionResult ByPreferance()
        {
            var model = GetByQueryStringParameter().ToList();

            foreach (var sportCenter in model)
            {
                sportCenter.Images = ImageHelper.SanitizeImageUrls(sportCenterService.GetImagesForSportCenter(sportCenter.Name).ToArray());
            }

            return View(model);
        }

        private IEnumerable<SportCenterViewModel> GetByQueryStringParameter()
        {
            if (Request.QueryString["City"] != null)
            {
                var param = (string)Request.QueryString["City"];

                return sportCenterService.All()
                      .OrderByDescending(x => x.CreatedOn)
                      .Where(x => x.Address.City == param)
                      .To<SportCenterViewModel>();
            }

            if (Request.QueryString["Neighbour"] != null)
            {
                var param = (string)Request.QueryString["Neighbour"];

                return sportCenterService.All()
                      .OrderByDescending(x => x.CreatedOn)
                      .Where(x => x.Address.Neighborhood == param)
                      .To<SportCenterViewModel>();
            }

            if (Request.QueryString["category"] != null)
            {
                var param = (string)Request.QueryString["category"];

                return categoryService.All()
                      .OrderByDescending(x => x.CreatedOn)
                      .FirstOrDefault(x => x.Name == param)
                      .SportCenters
                      .AsQueryable()
                      .To<SportCenterViewModel>();
            }

            return sportCenterService.All()
                        .OrderByDescending(x => x.CreatedOn)
                        .To<SportCenterViewModel>();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ByPreferance(SearchViewModel model)
        {
            string city = string.Empty;
            string neighbour = string.Empty;
            if (model.City != 0) city = addressService.All().FirstOrDefault(x => x.Id == model.City).City;
            if (model.Neighborhood != 0) neighbour = addressService.All().FirstOrDefault(x => x.Id == model.Neighborhood).Neighborhood;

            // cities and neighbours
            var fromCitiesAndNeihbours = sportCenterService.All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => city != string.Empty ? x.Address.City == city : x.Address.City != null)
                .Where(x => neighbour != string.Empty ? x.Address.Neighborhood == neighbour : x.Address.Neighborhood != null)
                .To<SportCenterViewModel>()
                .ToList();

            // categories
            var categoriesNames = new List<string>();

            if (model.SportCategories != null)
            {
                categoriesNames = Array
                    .ConvertAll(model.SportCategories.Split(','), p => p.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            var fromCategories = new List<SportCenterViewModel>();

            foreach (var category in categoriesNames)
            {
                fromCategories.AddRange(categoryService.All()
                    .OrderByDescending(x => x.CreatedOn)
                    .FirstOrDefault(x => x.Name == category)
                    .SportCenters
                    .AsQueryable()
                    .To<SportCenterViewModel>().ToList());
            }

            fromCitiesAndNeihbours.AddRange(fromCategories);
            fromCitiesAndNeihbours = fromCitiesAndNeihbours
                .Where(x => city != string.Empty ? x.Address.City == city : x.Address.City != null)
                .Where(x => neighbour != string.Empty ? x.Address.Neighborhood == neighbour : x.Address.Neighborhood != null)
                .ToList();

            foreach (var sportCenter in fromCitiesAndNeihbours)
            {
                sportCenter.Images = ImageHelper.SanitizeImageUrls(sportCenterService.GetImagesForSportCenter(sportCenter.Name).ToArray());
            }

            return View(fromCitiesAndNeihbours);
        }
    }
}