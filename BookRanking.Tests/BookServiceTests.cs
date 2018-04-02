using System;
using System.Linq;
using AutoMapper;
using BookRanking.Context;
using BookRanking.Data.Models;
using BookRanking.DTO;
using BookRanking.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookRanking.Tests
{
    [TestClass]
    public class BookServiceTests
    {
        [TestMethod]
        public void AddBook()
        {
            // Arrange
            var context = new Mock<IBookRankingDbContext>();
            var mockMapper = new Mock<IMapper>();

            var bookDTOMock = new Mock<BookDTO>();
            bookDTOMock.SetupGet(t => t.Title).Returns("zoro");
            var bookMock = new Mock<Book>();
            mockMapper.Setup(m => m.Map<Book>(bookDTOMock.Object)).Returns(bookMock.Object);
            var books = new FakeDbSet<Book>();
            context.Setup(c => c.Books).Returns(books);

            var publisherService = new PublisherService(context.Object, mockMapper.Object);
            var authorService = new AuthorService(context.Object, mockMapper.Object);

            var service = new BookService(authorService, publisherService, context.Object, mockMapper.Object);

            // Act
            service.AddBook(bookDTOMock.Object);

            // Assert
            Assert.IsTrue(context.Object.Books.Contains(bookMock.Object));
        }

        [TestMethod]
        public void AddBookEffort()
        {
            // Arrange
            var effortContext = new BookRankingDbContext(Effort.DbConnectionFactory.CreateTransient());
            var mockMapper = new Mock<IMapper>();

            var bookToReturn = new Book()
            {
            };

            mockMapper.Setup(x => x.Map<Book>(It.IsAny<BookDTO>())).Returns(bookToReturn);

            var publisherService = new PublisherService(effortContext, mockMapper.Object);
            var authorService = new AuthorService(effortContext, mockMapper.Object);
            var bookService = new BookService(authorService, publisherService, effortContext, mockMapper.Object);

            // Act
            var bookToAdd = new BookDTO();

            bookService.AddBook(bookToAdd);

            // Assert
            Assert.AreEqual(1, effortContext.Authors.Count());
        }
    }
}
