using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookRanking.Context;
using BookRanking.Data.Models;
using BookRanking.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRanking.Logic
{
    class PublisherService : BaseService
    {

        public PublisherService(IBookRankingDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public IQueryable<PublisherDTO> GetAllPublishers()
        {
            return this.dbContext.Publishers.ProjectTo<PublisherDTO>();
        }

        public void AddPublisher(PublisherDTO publisher)
        {
            if (publisher == null)
            {
                throw new ArgumentException("Publisher DTO cannot be null.");
            }

            if (string.IsNullOrEmpty(publisher.Name))
            {
                throw new ArgumentException("Publisher DTO's title cannot be null.");
            }

            if (!this.dbContext.Publishers.Any(x => x.Name == publisher.Name))
            {
                var publisherToAdd = this.mapper.Map<Publisher>(publisher);
                this.dbContext.Publishers.Add(publisherToAdd);
            }
            else
            {
                throw new ArgumentException("This publisher already exists.");
            }
        }
    }
}
