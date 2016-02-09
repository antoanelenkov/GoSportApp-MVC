using System.ComponentModel.DataAnnotations;

namespace GoSport.Data.Models
{
    public class Like
    {
        public int Id { get; set; }

        [Required]
        public bool isLiked { get; set; }

        public int AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int CommentId { get; set; }

        public virtual Comment  Comment { get; set; }
    }
}