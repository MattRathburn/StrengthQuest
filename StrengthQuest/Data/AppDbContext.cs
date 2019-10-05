using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
  public class AppDbContext : DbContext
  {

    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<MainLift> MainLifts { get; set; }
    public DbSet<SecondaryLift> SecondaryLifts { get; set; }
    public DbSet<Lift> Lifts { get; set; }

  }
}
