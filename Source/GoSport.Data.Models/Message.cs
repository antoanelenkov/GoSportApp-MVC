using System;
using GoSport.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace GoSport.Data.Models
{
    public class Message : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int RecieverId { get; set; }

        public virtual User Reciever { get; set; }

        public bool IsDeleted   {  get; set;  }

        public DateTime? DeletedOn { get; set; }
    }
}