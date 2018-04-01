using AutoMapper;
using BookRanking.Common.MapperContracts;
using BookRanking.Data.Models;
using System.Collections.Generic;

namespace BookRanking.DTO
{
    public class AuthorDTO : IMapTo<Author>
    {
        public AuthorDTO(string firstName, string lastName, string alias)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Alias = alias;
            this.BookDTOs = new List<BookDTO>();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Alias { get; private set; }

        public ICollection<BookDTO> BookDTOs { get; private set; }
    }
}
