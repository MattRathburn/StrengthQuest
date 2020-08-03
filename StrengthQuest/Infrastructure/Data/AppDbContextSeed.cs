using Entities.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext appDbContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!appDbContext.Days.Any())
                {
                    appDbContext.Days.AddRange(
                        GetPreconfiguredDbDays());

                    await appDbContext.SaveChangesAsync();
                }

                if (!appDbContext.Lifts.Any())
                {
                    appDbContext.Lifts.AddRange(
                        GetPreconfiguredLifts());

                    await appDbContext.SaveChangesAsync();
                }

                if (!appDbContext.LiftNames.Any())
                {
                    appDbContext.LiftNames.AddRange(
                        GetPreconfiguredLiftNames());

                    await appDbContext.SaveChangesAsync();
                }

                if (!appDbContext.LiftTypes.Any())
                {
                    appDbContext.LiftTypes.AddRange(
                        GetPreconfiguredLiftTypes());

                    await appDbContext.SaveChangesAsync();
                }

                if (!appDbContext.WeightMetrics.Any())
                {
                    appDbContext.WeightMetrics.AddRange(
                        GetPreconfiguredWeightMetrics());

                    await appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AppDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(appDbContext, loggerFactory, retryForAvailability);
                }
            }
        }

        // Add seed data
        static WeightMetric[] GetPreconfiguredWeightMetrics()
        {
            throw new NotImplementedException();
        }

        static LiftType[] GetPreconfiguredLiftTypes()
        {
            throw new NotImplementedException();
        }

        static LiftName[] GetPreconfiguredLiftNames()
        {
            throw new NotImplementedException();
        }

        static Lift[] GetPreconfiguredLifts()
        {
            throw new NotImplementedException();
        }

        static Days[] GetPreconfiguredDbDays()
        {
            throw new NotImplementedException();
        }
    }
}
