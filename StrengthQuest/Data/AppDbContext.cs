using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
  public class AppDbContext : DbContext
  {

    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Lift> Lifts { get; set; }
    public DbSet<LiftName> LiftNames { get; set; }
    public DbSet<LiftSequence> LiftSequences { get; set; }
    public DbSet<LiftType> LiftTypes { get; set; }
    public DbSet<WeightMetric> WeightMetrics { get; set; }

  }
}
