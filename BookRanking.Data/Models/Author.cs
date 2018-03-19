using System.Collections.Generic;

namespace BookRanking.Data.Models
{
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
            this.Publishers = new HashSet<Publisher>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Publisher> Publishers { get; set; }
    }
}
