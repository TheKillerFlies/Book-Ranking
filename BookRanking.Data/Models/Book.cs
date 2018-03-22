using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRanking.Data.Models
{
    public class Book
    {
        private ICollection<User> favouriteUsers;
        private ICollection<Author> authors;       

        public Book()
        {
            this.favouriteUsers = new HashSet<User>();
            this.authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        [Required]
        //[Index]
        public string Title { get; set; }

        public int PageCount { get; set; }

        [Required]
        [Index]
        public int PublishedYear { get; set; }

        public virtual ICollection<User> FavouriteUsers
        {
            get { return this.favouriteUsers; }
            set { this.favouriteUsers = value; }
        }

        public virtual ICollection<Author> Authors
        {
            get { return this.authors; }
            set { this.authors = value; }
        }

        public int PublisherId { get; set; }
        public Publisher Publisher{ get; set; }
    }
}
