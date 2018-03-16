using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookRanking.Data.Models
{
    public class Publisher
    {
        public Publisher()
        {
            this.Books = new HashSet<Book>();
            this.Authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
