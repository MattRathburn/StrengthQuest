using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data.Models
{
  public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
  {
    public AppDbContextFactory()
    {

    }

    public AppDbContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Presentation/appsettings.json")
        .Build();
      var builder = new DbContextOptionsBuilder<AppDbContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");
      builder.UseSqlServer(connectionString);
      return new AppDbContext(builder.Options);

    }
  }
}
