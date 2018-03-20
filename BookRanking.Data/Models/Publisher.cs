using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRanking.Data.Models
{
    public class Publisher
    {
        private ICollection<Book> books;
        private ICollection<Author> authors;
        public Publisher()
        {
            this.books = new HashSet<Book>();
            this.authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        public virtual ICollection<Author> Authors
        {
            get { return this.authors; }
            set { this.authors = value; }
        }
    }
}
