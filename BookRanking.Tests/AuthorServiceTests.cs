using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    public class AuthorServiceTests
    {
        [TestMethod]
        public void AddAuthor()
        {
            // Arrange
            //var context = new BookRankingDbContext(DbConnectionFactory.CreateTransient());
            var context = new Mock<IBookRankingDbContext>();
            var mockMapper = new Mock<IMapper>();
            var authorDTOMock = new Mock<AuthorDTO>();
            var authorMock = new Mock<Author>();
            mockMapper.Setup(m => m.Map<Author>(authorDTOMock.Object)).Returns(authorMock.Object);
            var authors = new FakeDbSet<Author>();
            context.Setup(c => c.Authors).Returns(authors);

            var service = new AuthorService(context.Object, mockMapper.Object);

            // Act
            service.AddAuthor(authorDTOMock.Object);

            // Assert
            Assert.IsTrue(context.Object.Authors.Contains(authorMock.Object));
        }

        [TestMethod]
        public void AddAuthorEffort()
        {
            // Arrange
            var effortContext = new BookRankingDbContext(Effort.DbConnectionFactory.CreateTransient());
            var mockMapper = new Mock<IMapper>();

            var authorToReturn = new Author
            {
                FirstName = "Zaio",
                LastName = "Baio",
                Alias = "NUPogodi"
            };

            mockMapper.Setup(x => x.Map<Author>(It.IsAny<AuthorDTO>())).Returns(authorToReturn);

            var service = new AuthorService(effortContext, mockMapper.Object);

            // Act
            var authorToAdd = new AuthorDTO("Zaio", "Baio", "NUPogodi");

            service.AddAuthor(authorToAdd);

            // Assert
            Assert.AreEqual(1, effortContext.Authors.Count());
        }
    }
}
