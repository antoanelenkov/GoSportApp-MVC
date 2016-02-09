using GoSport.Data.Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GoSport.Data.Models
{
    public class User : IdentityUser, IDeletableEntity
    {
        private ICollection<Message> messages;
        private ICollection<SportCategory> favouriteCategories;
        private ICollection<Like> likes;

        public User()
        {
            this.messages = new HashSet<Message>();
            this.favouriteCategories = new HashSet<SportCategory>();
            this.likes = new HashSet<Like>();

            this.CreatedOn = DateTime.Now;
        }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Neighborhood { get; set; }

        public string Facebook { get; set; }

        public string AvatarUrl { get; set; }

        public string AboutMe { get; set; }

        public int PositiveVotes { get; set; }

        public int NegativeVotes { get; set; }

        public ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.Messages = value; }
        }

        public ICollection<SportCategory> FavouriteCategories
        {
            get { return this.favouriteCategories; }
            set { this.FavouriteCategories = value; }
        }

        public ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
