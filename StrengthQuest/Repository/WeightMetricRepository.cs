using Contracts;
using Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
  public class WeightMetricRepository : IWeightMetricRepository
  {

    private AppDbContext _context;

    public WeightMetricRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<WeightMetric>> GetAllAsync()
    {
      try
      {
        return await _context.WeightMetrics.ToListAsync();
      }
      catch (Exception ex)
      {
        // logging
        return null;
      }

    }

    public async Task<WeightMetric> GetAsync(Guid id)
    {
      try
      {
        return await _context.WeightMetrics.FindAsync(id);
      }
      catch (Exception ex)
      {
        // logging
        return null;
      }
    }

    public async Task<WeightMetric> CreateAsync(WeightMetric weightMetric)
    {
      try
      {
        await _context.WeightMetrics.AddAsync(weightMetric);
      }
      catch (Exception ex)
      {
        // logging
        return weightMetric;
      }
      return weightMetric;
    }

    public async Task<WeightMetric> UpdateAsync(WeightMetric weightMetric)
    {
      try
      {
        _context.Entry(weightMetric).State = EntityState.Modified;
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        // logging
        return weightMetric;
      }
      return weightMetric;
    }

    public async Task<WeightMetric> DeleteAsync(Guid id)
    {
      var weightMetric = await _context.WeightMetrics.FindAsync(id);
      if(weightMetric == null)
      {
        weightMetric.Status.Message = "Unable to find weightMetric";
        return weightMetric;
      }
      try
      {
        _context.WeightMetrics.Remove(weightMetric);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        // logging
        return weightMetric;
      }
      return weightMetric;
    }

    public async Task<bool> SaveAsync()
    {
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        // logging
        return false;
      }
      return true;

    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
      if (!disposedValue)
      {
        if (disposing)
        {
          _context.Dispose();
        }

        disposedValue = true;
      }
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
      // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
      Dispose(true);
      // TODO: uncomment the following line if the finalizer is overridden above.
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}
