using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRanking.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public Author Author { get; set; }

        public virtual ICollection<User> UserFavourite { get; set; }
    }
}
