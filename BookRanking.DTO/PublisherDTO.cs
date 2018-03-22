using BookRanking.Common.MapperContracts;
using BookRanking.Data.Models;

namespace BookRanking.DTO
{
    public class PublisherDTO : IMapTo<Publisher>
    {
        public string Name { get; set; }
    }
}
