using BookRanking.DTO;
using System.Linq;

namespace BookRanking.Logic.Contracts
{
    public interface IBookService
    {
        IQueryable<BookDTO> GetAllBooks();

       // void AddOrUpdateBook(BookDTO bookDTO);

        void RemoveBook(BookDTO bookDTO);

        void AddBook(BookDTO bookDTO);

        void UpdateBook(BookDTO bookDTO);


    }
}
