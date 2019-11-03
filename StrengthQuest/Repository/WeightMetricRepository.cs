using Contracts;
using Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
  public class WeightMetricRepository : IWeightMetricRepository
  {

    private AppDbContext _context;

    public WeightMetricRepository(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<WeightMetric> GetAll()
    {
      return _context.WeightMetrics.ToList();
    }

    public WeightMetric GetById(int id)
    {
      return _context.WeightMetrics.Find(id);
    }

    public void Insert(WeightMetric weightMetric)
    {
      _context.WeightMetrics.Add(weightMetric);
    }

    public void Update(WeightMetric weightMetric)
    {
      _context.Entry(weightMetric).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      WeightMetric weightMetric = _context.WeightMetrics.Find(id);
      _context.WeightMetrics.Remove(weightMetric);
    }

    public void Save()
    {
      _context.SaveChanges();
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
