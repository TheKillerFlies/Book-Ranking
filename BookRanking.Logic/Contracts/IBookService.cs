using BookRanking.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BookRanking.Logic.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAllBooks();

        void RemoveBook(BookDTO bookDTO);

        void AddBook(BookDTO bookDTO, AuthorDTO author, PublisherDTO publisher);

        BookDTO FindBookByTitle(string title);

       // void UpdateBook(BookDTO bookDTO);
    }
}
