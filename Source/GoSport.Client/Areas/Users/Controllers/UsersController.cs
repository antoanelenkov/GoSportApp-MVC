using GoSport.Client.Controllers;
using GoSport.Client.Infrastructure.Mapping;
using GoSport.Client.ViewModels.Users;
using GoSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoSport.Client.Areas.Users.Controllers
{
    [Authorize]
    public class UsersController: BaseController
    {
        IUserService usersService;

        public UsersController(
            ISportCategoryService sportCategories,
            IAddressService addressService,
            ISportCategoryService categoryService,
            ISportCenterService sportCenterService,
            IUserService usersService)
            : base(sportCategories, addressService, categoryService)
        {
            this.usersService=usersService;
        }

        [HttpGet]
        public ActionResult All()
        {
            var users = usersService.GetAll().To<UserProfileViewModel>().ToList();

            return View(users);
        }

        [HttpGet]
        public new ActionResult Profile(string id)
        {
            var userFromDb = usersService.GetUserById(id);
            var model = new UserProfileViewModel();

            if (userFromDb != null)
            {
                model = Mapper.Map<UserProfileViewModel>(userFromDb);
                model.AvatarUrl = String.Format("/Content/Avatars/{0}.jpg", userFromDb.UserName);
            }

            return View(model);
        }
    }
}