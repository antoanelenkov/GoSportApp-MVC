using GoSport.Client.Infrastructure.Filters;
using GoSport.Client.Infrastructure.Mapping;
using GoSport.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoSport.Client.ViewModels.SportCenters
{
    public class AddSportCenterViewModel : IMapTo<SportCenter>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Exact Address")]
        public string ExactAddress { get; set; }

        public string City { get; set; }

        public string Neighborhood { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [ValidPhoneNumber]
        public string PhoneNumber { get; set; }

        [Display(Name = "Sport Center categories")]
        public string SportCenterCategories { get; set; }

        [Display(Name = "Picture 1")]
        public HttpPostedFileBase UplodadedImage1 { get; set; }

        [Display(Name = "Picture 2")]
        public HttpPostedFileBase UplodadedImage2 { get; set; }

        [Display(Name = "Picture 3")]
        public HttpPostedFileBase UplodadedImage3 { get; set; }

        [Display(Name = "Picture 3")]
        public HttpPostedFileBase UplodadedImage4 { get; set; }
    }
}