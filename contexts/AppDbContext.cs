using System;
using Microsoft.EntityFrameworkCore;
using sample_dotnet_rest.models;

namespace sample_dotnet_rest.contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var envHost = Environment.GetEnvironmentVariable("SQL_HOST");
            var envUser = Environment.GetEnvironmentVariable("SQL_USER");
            var envPassword = Environment.GetEnvironmentVariable("SQL_PASSWORD");

            var host = envHost ?? "localhost";
            var user = envUser ?? "sa";
            var password = envPassword ?? "yourStrong(!)Password";
           
            optionsBuilder.UseSqlServer(@"Server=" + host + ";Database=master;User Id="+ user +";Password=" + password);
        }  
    }
}