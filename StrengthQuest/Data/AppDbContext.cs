using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Lift> Lifts { get; set; }
        public DbSet<LiftName> LiftNames { get; set; }
        public DbSet<LiftType> LiftTypes { get; set; }
        public DbSet<WeightMetric> WeightMetrics { get; set; }
        public DbSet<Days> Days { get; set; }
    }
}
