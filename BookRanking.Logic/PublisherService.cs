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
    public class PublisherService : BaseService, IPublisherService
    {

        public PublisherService(IBookRankingDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public IEnumerable<PublisherDTO> GetAllPublishers()
        {
            var publishers = this.dbContext.Publishers;
            var publisherDTOs = new List<PublisherDTO>();

            foreach (var publisher in publishers)
            {
                publisherDTOs.Add(this.mapper.Map<PublisherDTO>(publisher));
            }
            return publisherDTOs;
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
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("This publisher already exists.");
            }
        }

        public void RemovePublisher(PublisherDTO publisher)
        {
            if(this.dbContext.Publishers.Any(x=>x.Name == publisher.Name))
            {
                var publisherToRemove = this.dbContext.Publishers.First(x => x.Name == publisher.Name);
                this.dbContext.Publishers.Remove(publisherToRemove);
                this.dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("The publisher that you are trying to remove does not exist.");
            }
        }
    }
}
