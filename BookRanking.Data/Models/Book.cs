using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRanking.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.FavouriteUsers = new HashSet<User>();
            this.Authors = new HashSet<Author>();
            this.Publishers = new HashSet<Publisher>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<User> FavouriteUsers { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<Publisher> Publishers { get; set; }
    }
}
