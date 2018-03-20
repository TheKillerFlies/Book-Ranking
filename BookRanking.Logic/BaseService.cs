using AutoMapper;
using BookRanking.Context;

namespace BookRanking.Logic
{
    public abstract class BaseService
    {
        protected readonly IBookRankingDbContext dbContext;
        protected readonly IMapper mapper;

        protected BaseService(IBookRankingDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
    }
}
