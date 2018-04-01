using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BookRanking.Tests
{
    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private readonly List<T> data;

        public FakeDbSet()
        {
            this.data = new List<T>();
        }

        public FakeDbSet(params T[] entities)
        {
            this.data = new List<T>(entities);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        public Expression Expression
        {
            get { return Expression.Constant(this.data.AsQueryable()); }
        }

        public Type ElementType
        {
            get { return typeof(T); }
        }

        public IQueryProvider Provider
        {
            get { return this.data.AsQueryable().Provider; }
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            this.data.Add(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            this.data.Remove(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            this.data.Add(entity);
            return entity;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local
        {
            get { return new ObservableCollection<T>(this.data); }
        }
    }
}