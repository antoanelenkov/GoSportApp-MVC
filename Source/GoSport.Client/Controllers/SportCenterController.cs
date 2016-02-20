using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoSport.Client.ViewModels.SportCenters;
using GoSport.Client.Infrastructure.Mapping;
using GoSport.Data.Models;
using System.IO;

namespace GoSport.Client.Controllers
{
    public class SportCenterController : BaseController
    {
        ISportCenterService sportCenterService;

        public SportCenterController(
            ISportCategoryService sportCategories,
            IAddressService addressService,
            ISportCategoryService categoryService,
            ISportCenterService sportCenterService)
            : base(sportCategories, addressService, categoryService)
        {
            this.sportCenterService = sportCenterService;
        }

        public ActionResult SportCenters()
        {
            var all = sportCenterService.All().To<SportCenterViewModel>().ToList();

            Response.Write("All sport centers are: " + all.Count());
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddSportCenterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var sportCenter = Mapper.Map<SportCenter>(model);

                sportCenter = sportCenterService.Create(sportCenter);

                // address
                int addressId;
                if (int.TryParse(model.Neighborhood, out addressId))
                {
                    addressService.AddAddressForSportCenter(sportCenter.Name, addressId);
                }

                if (model.SportCategories != null)
                {
                    var categoriesNames = model.SportCategories
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(x => !string.IsNullOrEmpty(x));

                    categoryService.AddCategoriesForSportCenter(categoriesNames, sportCenter.Name);
                }

                this.AddImages(model);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        private void AddImages(AddSportCenterViewModel model)
        {
            var imagesUrls = new List<string>();

            if (model.UplodadedImage1 != null)
            {
                var image = SaveImage(model.UplodadedImage1, model.Name, 1);
                imagesUrls.Add(image);
            }
            if (model.UplodadedImage2 != null)
            {
                var image = SaveImage(model.UplodadedImage1, model.Name, 2);
                imagesUrls.Add(image);
            }
            if (model.UplodadedImage3 != null)
            {
                var image = SaveImage(model.UplodadedImage1, model.Name, 3);
                imagesUrls.Add(image);
            }
            if (model.UplodadedImage4 != null)
            {
                var image = SaveImage(model.UplodadedImage1, model.Name, 4);
                imagesUrls.Add(image);
            }
            if (model.UplodadedImage5 != null)
            {
                var image = SaveImage(model.UplodadedImage1, model.Name, 5);
                imagesUrls.Add(image);
            }
            if (model.UplodadedImage6 != null)
            {
                var image = SaveImage(model.UplodadedImage1, model.Name, 6);
                imagesUrls.Add(image);
            }
            if (model.UplodadedImage7 != null)
            {
                var image = SaveImage(model.UplodadedImage1, model.Name, 7);
                imagesUrls.Add(image);
            }
            if (model.UplodadedImage8 != null)
            {
                var image = SaveImage(model.UplodadedImage1, model.Name, 8);
                imagesUrls.Add(image);
            }
            if (model.UplodadedImage9 != null)
            {
                var image = SaveImage(model.UplodadedImage1, model.Name, 9);
                imagesUrls.Add(image);
            }

            sportCenterService.AddImagesToSportCenter(model.Name,imagesUrls);
        }

        private string SaveImage(HttpPostedFileBase image, string sportCenterName, int picturerNumber)
        {
            var imageUrl = this.sportCenterPath  + sportCenterName  + picturerNumber + ".jpg";
            using (FileStream output = System.IO.File.OpenWrite(imageUrl))
            {
                CopyStream(image.InputStream, output);
            }

            return imageUrl;
        }
    }
}