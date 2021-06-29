using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using ProductsReviewsAngular.Models;

namespace ProductsReviewsAngular
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<Models.ApplicationContext>
    {
        public Models.ApplicationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ApplicationContext(builder.Options);
        }
    }
}
