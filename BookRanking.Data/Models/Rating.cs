using System.ComponentModel.DataAnnotations;

namespace BookRanking.Data.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Book Book { get; set; }

        [Required]
        [Range(1, 5)]
        public int Score { get; set; }
    }
}
