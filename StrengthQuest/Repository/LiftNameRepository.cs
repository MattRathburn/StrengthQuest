using Contracts;
using Contracts.IRepositories;
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
  public class LiftNameRepository : ILiftNameRepository
  {

    private readonly AppDbContext _context;
    private readonly ILoggerService _logger;

    public LiftNameRepository(AppDbContext context, ILoggerService logger)
    {
      _context = context;
      _logger = logger;
    }

    public IEnumerable<LiftName> GetAll()
    {
      return _context.LiftNames.AsEnumerable();
    }

    public LiftName Get(string id)
    {
      return _context.LiftNames.Find(id);
    }

    public LiftName GetByName(string name)
    {
      return _context.LiftNames.FirstOrDefault(n => n.Name == name);
    }

    public async Task<LiftName> CreateAsync(LiftName liftName)
    {
      try
      {
        await _context.LiftNames.AddAsync(liftName);
      }
      catch (Exception ex)
      {
        // Logging
        return liftName;
      }
      return liftName;      
    }

    public async Task<LiftName> UpdateAsync(LiftName liftName)
    {

      try
      {
        _context.Entry(liftName).State = EntityState.Modified;
        await _context.SaveChangesAsync();
      }
      catch  (Exception ex)
      {
        // logging
        return liftName;
      }
      return liftName;

    }

    public async Task<LiftName> DeleteAsync(string id)
    {
      var liftName = await _context.LiftNames.FindAsync(id);

      if(liftName == null)
      {
        return liftName;
      }

      try
      {
        _context.LiftNames.Remove(liftName);
      }
      catch (Exception ex)
      {
        // logging
        return liftName;
      }
      return liftName;

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
