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
            var mockContext = new Mock<IBookRankingDbContext>();
            var mockMapper = new Mock<IMapper>();

            var service = new AuthorService(mockContext.Object, mockMapper.Object);

            List<Author> authors = new List<Author>() { };
            var authorsMock = authors.GetQueryableMockDbSet();

            var authorToAdd = new AuthorDTO("Pencho", "Karalijchev", "PPP");
            mockContext.Setup(x => x.Authors).Returns(authorsMock);
            mockContext.Setup(x => x.Authors.Add(It.Is<Author>(a => a.FirstName == authorToAdd.FirstName && a.LastName== authorToAdd.LastName && a.Alias== authorToAdd.Alias)));

            // Act

            service.AddAuthor(authorToAdd);

            // Assert
            mockContext.Verify(x => x.Authors.Add(It.Is<Author>(a => a.FirstName == authorToAdd.FirstName && a.LastName == authorToAdd.LastName && a.Alias == authorToAdd.Alias)), Times.Once);
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
