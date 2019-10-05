using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
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
      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
      optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StrengthQuestTest;Trusted_Connection=True;MultipleActiveResultSets=true");
      return new AppDbContext(optionsBuilder.Options);
    }
  }
}
