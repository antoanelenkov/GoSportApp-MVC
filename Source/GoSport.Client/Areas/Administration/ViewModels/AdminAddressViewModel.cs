using GoSport.Client.Infrastructure.Mapping;
using GoSport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoSport.Client.Areas.Administration.ViewModels
{
    public class AdminAddressViewModel : IMapFrom<Address>
    {
        [HiddenInput]
        public int Id { get; set; }

        public string Neighboorhood { get; set; }

        public string City { get; set; }
    }
}