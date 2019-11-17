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
  public class LiftNameRepository : ILiftNameRepository
  {

    private readonly AppDbContext _context;
    private readonly ILoggerService _logger;

    public LiftNameRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<LiftName>> GetAllAsync()
    {
      return await _context.LiftNames.ToListAsync();
    }

    public async Task<LiftName> GetAsync(Guid id)
    {
      return await _context.LiftNames.FindAsync(id);
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

    public async Task<LiftName> DeleteAsync(Guid id)
    {
      var liftName = await _context.LiftNames.FindAsync(id);

      if(liftName == null)
      {
        liftName.Status.Message = "Unable to find LiftName";
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
