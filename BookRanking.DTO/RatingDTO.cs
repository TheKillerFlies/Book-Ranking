using AutoMapper;
using BookRanking.Common.MapperContracts;
using BookRanking.Data.Models;

namespace BookRanking.DTO
{
    public class RatingDTO : IMapTo<Rating>
    {
        public User User { get; set; }
        public Book Book { get; set; }
        public int Score { get; set; }
    }
}
