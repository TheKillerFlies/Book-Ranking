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
    public class AuthorService : IAuthorService
    {
        private readonly IBookRankingDbContext dbContext;
        private readonly IMapper mapper;

        public AuthorService(IBookRankingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IQueryable<AuthorDTO> GetAllAuthors()
        {
            return this.dbContext.Authors.ProjectTo<AuthorDTO>();
        }

        public void AddAuthor(AuthorDTO author)
        {
            if (author == null)
            {
                throw new ArgumentException();
            }

            var authorToAdd = this.mapper.Map<Author>(author);

            this.dbContext.Authors.Add(authorToAdd);
            this.dbContext.SaveChanges();
        }
    }
}
