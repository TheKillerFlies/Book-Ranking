using AutoMapper;
using BookRanking.Context;
using BookRanking.Logic.Contracts;

namespace BookRanking.Logic
{
    public class BaseService: IBaseService
    {
        protected readonly IBookRankingDbContext dbContext;
        protected readonly IMapper mapper;

        public BaseService(IBookRankingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
    }
}
