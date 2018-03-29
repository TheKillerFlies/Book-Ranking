using System;
using System.Data.Entity;
using BookRanking.Context;
using BookRanking.Context.Migrations;
using Autofac;
using System.Reflection;
using BookRanking.Common;
using BookRanking.Logic.Contracts;
using BookRanking.DTO;
using BookRanking.Logic;
using BookRanking.Client.AutofacModules;
using BookRanking.Client.Engine.Contracts;

namespace BookRanking.Client
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            var injectionConfig = new AutofacModule();
            builder.RegisterModule(injectionConfig);

            var container = builder.Build();

            var engine = container.Resolve<IBookEngine>();
            Init();
            engine.Start();

       
        }

        private static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookRankingDbContext, Configuration>());

            AutomapperConfiguration.Initialize();
        }
    }
}
