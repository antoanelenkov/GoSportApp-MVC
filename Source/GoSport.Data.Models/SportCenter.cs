using GoSport.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoSport.Data.Models
{
    public class SportCenter : AuditInfo, IDeletableEntity
    {
        private ICollection<string> picturesUrls;
        private ICollection<Comment> comments;

        public SportCenter()
        {
            this.picturesUrls = new HashSet<string>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public int SportCategoryId { get; set; }

        public virtual SportCategory SportCategory { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public SportCenterRating Rating { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<string> PicturesUrls
        {
            get { return this.picturesUrls; }
            set { this.picturesUrls = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
