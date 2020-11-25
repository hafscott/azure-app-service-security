using Benday.EfCore.SqlServer.TestApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benday.EfCore.SqlServer.IntegrationTests
{
    [TestClass]
    public static class EfCoreUnitTestSetup
    {
        private static string _ConnectionString = "Server=localhost; Database=benday-efcore-sqlserver; User Id=sa; Password=Pa$$word;";
        
        [AssemblyInitializeAttribute]
        public static void OnAssemblyInitialize(TestContext testContext)
        {
            using (var dbcontext = GetDbContext())
            {
                dbcontext.Database.EnsureCreated();
            }
        }
        
        private static ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
            builder.AddConsole()
            .AddFilter(DbLoggerCategory.Database.Command.Name,
            LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
            .GetService<ILoggerFactory>();
        }
        
        private static TestDbContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            
            optionsBuilder.UseLoggerFactory(GetLoggerFactory());
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlServer(_ConnectionString);
            
            var context = new TestDbContext(optionsBuilder.Options);
            
            return context;
        }
    }
}
