using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookRanking.Context;
using BookRanking.Data.Models;
using BookRanking.DTO;
using BookRanking.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookRanking.Logic
{
    public class AuthorService : BaseService, IAuthorService
    {
        public AuthorService(IBookRankingDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public IEnumerable<AuthorDTO> GetAllAuthors()
        {
           var authors = this.dbContext.Authors;
           var authorDTOs = new List<AuthorDTO>();

            foreach (var author in authors)
            {
               authorDTOs.Add(this.mapper.Map<AuthorDTO>(author));
            }
            return authorDTOs;
        }

        public void AddAuthor(AuthorDTO author)
        {
            if (author == null)
            {
                throw new ArgumentException();
            }
            if (!this.dbContext.Authors
                        .Any(x => x.FirstName == author.FirstName
                        && x.LastName == author.LastName
                        && x.Alias == author.Alias))
            {
                var authorToAdd = this.mapper.Map<Author>(author);
                this.dbContext.Authors.Add(authorToAdd);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This author already exists.");
            }
            
        }

        public void RemoveAuthor(AuthorDTO author)
        {
            if(this.dbContext.Authors
                        .Any(x => x.FirstName == author.FirstName
                        && x.LastName == author.LastName
                        && x.Alias == author.Alias))
            {
                var authorToRemove = this.dbContext.Authors
                        .First(x => x.FirstName == author.FirstName
                        && x.LastName == author.LastName
                        && x.Alias == author.Alias);

                this.dbContext.Authors.Remove(authorToRemove);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("The author you are trying to remove does not exist.");
            }
        }
        public AuthorDTO GetAuthorByAlias(string alias)
        {
            var author = this.dbContext.Authors.First(x => x.Alias == alias);
            return this.mapper.Map<AuthorDTO>(author);
        }
    }
}
