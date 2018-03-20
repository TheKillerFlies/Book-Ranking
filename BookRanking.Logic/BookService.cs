using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookRanking.Context;
using BookRanking.Data.Models;
using BookRanking.DTO;
using BookRanking.Logic.Contracts;
using System;
using System.Linq;

namespace BookRanking.Logic
{
    public class BookService : BaseService, IBookService
    {
        private IAuthorService authorService;

        public BookService(IAuthorService authorService, IBookRankingDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
            this.authorService = authorService;
        }

        public IQueryable<BookDTO> GetAllBooks()
        {
            return this.dbContext.Books.ProjectTo<BookDTO>();
        }

        public void AddOrUpdateBook(BookDTO bookDTO)
        {
            if (bookDTO is null)
            {
                throw new ArgumentException("Book DTO cannot be null.");
            }

            if (string.IsNullOrEmpty(bookDTO.Title))
            {
                throw new ArgumentException("Book DTO's title cannot be null.");
            }

            // TODO: Add author collection check.

            foreach (var authorDTO in bookDTO.AuthorDTOs)
            {
                var author = this.authorService.GetAuthorByAlias(authorDTO.Alias);
                if (author is null)
                {
                    this.authorService.AddAuthor(authorDTO);
                }
            }

            if (!this.dbContext.Books.Any(b => b.Title == bookDTO.Title && b.PublishedYear == bookDTO.PublishedYear))
            {
                var bookToAdd = this.mapper.Map<Book>(bookDTO);
                this.dbContext.Books.Add(bookToAdd);
            }
            else
            {
                var bookToUpdate = this.dbContext.Books.First(b =>
                    b.Title == bookDTO.Title && b.PublishedYear == bookDTO.PublishedYear);

                bookToUpdate.Title = bookDTO.Title;
                bookToUpdate.PublishedYear = bookDTO.PublishedYear;
                bookToUpdate.Authors = this.authorService.GetAllAuthors()
                    .Where(a => bookDTO.AuthorDTOs.Any(r => r.Alias == a.Alias)).ProjectTo<Author>().ToList();
            }

            this.dbContext.SaveChanges();
        }

        public void RemoveBook(BookDTO bookDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
