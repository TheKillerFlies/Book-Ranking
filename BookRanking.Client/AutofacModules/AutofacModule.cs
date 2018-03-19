using Autofac;
using AutoMapper;
using BookRanking.Context;
using BookRanking.Logic;
using BookRanking.Logic.Contracts;

namespace BookRanking.Client.AutofacModules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRankingDbContext>().As<IBookRankingDbContext>().InstancePerDependency();
            builder.RegisterType<AuthorService>().As<IAuthorService>().InstancePerDependency();
            builder.Register(x => Mapper.Instance);
        }
    }
}
