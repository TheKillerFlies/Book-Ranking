using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRanking.Data.Models
{
    public class Author
    {
        private ICollection<Book> books;
        private ICollection<Publisher> publishers;

        public Author()
        {
            this.books = new HashSet<Book>();
            this.publishers = new HashSet<Publisher>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Alias { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        public virtual ICollection<Publisher> Publishers
        {
            get { return this.publishers; }
            set { this.publishers = value; }
        }
    }
}
