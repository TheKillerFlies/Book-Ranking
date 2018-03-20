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
    public class AuthorService : BaseService, IAuthorService
    {
        public AuthorService(IBookRankingDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
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

        public AuthorDTO GetAuthorByAlias(string alias)
        {
            var collection = this.dbContext.Authors.ProjectTo<AuthorDTO>();
            foreach (var authorDto in collection)
            {
                if (authorDto.Alias == alias)
                {
                    return authorDto;
                }
            }

            return null;
        }
    }
}
