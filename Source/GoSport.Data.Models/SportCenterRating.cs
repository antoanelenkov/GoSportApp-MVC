using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoSport.Data.Models
{
    public class SportCenterRating
    {
        [Key, ForeignKey("SportCenter")]
        public int SportCenterId { get; set; }

        public virtual SportCenter SportCenter { get; set; }

        public int Total { get; set; }

        public int Comfort { get; set; }

        public int Service { get; set; }

        public int Price { get; set; }

        public int Trainers { get; set; }
    }
}