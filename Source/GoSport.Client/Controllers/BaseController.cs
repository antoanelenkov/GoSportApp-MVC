using AutoMapper;
using GoSport.Client.Infrastructure.Mapping;
using MvcTemplate.Services.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoSport.Client.Controllers
{
    public abstract  class BaseController : Controller
    {
        protected  string userAvatarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Content\Avatars\");

        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}