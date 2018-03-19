using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookRanking.Tests
{
    public static class DbSetExtensions
    {
        public static IDbSet<T> GetQueryableMockDbSet<T>(this List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<IDbSet<T>>();
            dbSet.Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return dbSet.Object;
        }
    }
}
