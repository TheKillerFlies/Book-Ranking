using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookRanking.Data.Models
{
    public class User
    {
        public User()
        {
            this.FavouriteCollection = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string LastName { get; set; }

        [Required]  
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [System.ComponentModel.DefaultValue("")]
        [MinLength(10)]
        public string PasswordHash { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public virtual ICollection<Book> FavouriteCollection { get; set; }
    }
}
