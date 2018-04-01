using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRanking.Data.Models
{
    public class Book
    {
        private ICollection<User> favouriteUsers;

        public Book()
        {
            this.favouriteUsers = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int PageCount { get; set; }

        [Required]
        public int PublishedYear { get; set; }

        public virtual ICollection<User> FavouriteUsers
        {
            get { return this.favouriteUsers; }
            set { this.favouriteUsers = value; }
        }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
