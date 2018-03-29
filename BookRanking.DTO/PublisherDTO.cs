using AutoMapper;
using BookRanking.Common.MapperContracts;
using BookRanking.Data.Models;


namespace BookRanking.DTO
{
    public class PublisherDTO : IMapTo<Publisher>
    {
        public PublisherDTO(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }

   
    }
}
