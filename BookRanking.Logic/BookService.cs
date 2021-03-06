﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookRanking.Context;
using BookRanking.Data.Models;
using BookRanking.DTO;
using BookRanking.Logic.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookRanking.Logic
{
    public class BookService : BaseService, IBookService
    {
        private IAuthorService authorService;
        private IPublisherService publisherService;

        public BookService(IAuthorService authorService, IPublisherService publisherService, IBookRankingDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
            this.authorService = authorService;
            this.publisherService = publisherService;
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var books = this.dbContext.Books;
            var bookDTOs = new List<BookDTO>();

            foreach (var book in books)
            {
                bookDTOs.Add(this.mapper.Map<BookDTO>(book));
            }
            return bookDTOs;
        }

        public void AddBook(BookDTO book)
        {
            if (book == null)
            {
                throw new ArgumentException("Book DTO cannot be null.");
            }

            if (string.IsNullOrEmpty(book.Title))
            {
                throw new ArgumentException("Book DTO's title cannot be null.");
            }

            if (!this.dbContext.Books.Any(b => b.Title == book.Title && b.PublishedYear == book.PublishedYear))
            {
                if (!this.dbContext.Authors
                   .Any(x => x.FirstName == book.Author.FirstName
                   && x.LastName == book.Author.LastName
                   && x.Alias == book.Author.Alias))
                {
                    this.authorService.AddAuthor(book.Author);
                }

                if (!this.dbContext.Publishers.ToList().Any(x => x.Name == book.Publisher.Name))
                {
                    this.publisherService.AddPublisher(book.Publisher);
                }

                var bookToAdd = this.mapper.Map<Book>(book);
                bookToAdd.Author = this.dbContext.Authors.First(a => a.FirstName == book.Author.FirstName && a.LastName == book.Author.LastName && a.Alias == book.Author.Alias);
                bookToAdd.Publisher = this.dbContext.Publishers.First(p => p.Name == book.Publisher.Name);
                this.dbContext.Books.Add(bookToAdd);

                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This book already exists.");
            }
        }

        public BookDTO FindBookByTitle(string title)
        {
            if (this.dbContext.Books.Any(x => x.Title == title))
            {
                var book = this.dbContext.Books.First(x => x.Title == title);
                book.Publisher = this.dbContext.Publishers.First(p => p.Id == book.PublisherId);
                return Mapper.Instance.Map<BookDTO>(book);
            }
            else
            {
                throw new ArgumentException("This book does not exist.");
            }
        }

        public void RemoveBook(BookDTO bookdto)
        {
            var booktoremove = this.dbContext.Books.First(b =>
                b.Title == bookdto.Title && b.PublishedYear == bookdto.PublishedYear);
            this.dbContext.Books.Remove(booktoremove);
            this.dbContext.SaveChanges();
        }
    }
}
