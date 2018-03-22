using System.Linq;
using BookRanking.DTO;

namespace BookRanking.Logic
{
    public interface IPublisherService
    {
        void AddPublisher(PublisherDTO publisher);
        IQueryable<PublisherDTO> GetAllPublishers();
    }
}