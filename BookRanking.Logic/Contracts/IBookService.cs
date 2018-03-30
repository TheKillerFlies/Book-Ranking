using BookRanking.DTO;
using System.Linq;

namespace BookRanking.Logic.Contracts
{
    public interface IBookService
    {
        IQueryable<BookDTO> GetAllBooks();

        void RemoveBook(BookDTO bookDTO);

        void AddBook(BookDTO bookDTO);

        BookDTO FindBookByTitle(string title);
       // void UpdateBook(BookDTO bookDTO);


    }
}
