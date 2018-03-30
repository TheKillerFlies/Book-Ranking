using AutoMapper;
using BookRanking.Common.MapperContracts;
using BookRanking.Data.Models;

namespace BookRanking.DTO
{
    public class UserDTO : IMapTo<User>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
