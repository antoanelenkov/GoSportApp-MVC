using GoSport.Client.Infrastructure.Mapping;
using GoSport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoSport.Client.ViewModels.SportCenters
{
    public class SportCenterViewModel : IMapFrom<SportCenter>
    {
        public string City { get; set; }
    }
}