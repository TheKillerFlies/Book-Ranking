using System.Collections.Generic;
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

            mockContext.Setup(x => x.Authors).Returns(authorsMock);
            mockContext.Setup(x => x.Authors.Add(It.IsAny<Author>())).Callback<Author>(x => authors.Add(x));

            // Act
            var authorToAdd = new AuthorDTO()
            {
                FirstName = "Pencho",
                LastName = "Karalijchev"
            };

            service.AddAuthor(authorToAdd);

            // Assert
            mockContext.Verify(x => x.Authors.Add(It.IsAny<Author>()), Times.Once);
        }
    }
}
