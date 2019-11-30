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
  public class LiftTypeRepository : ILiftTypeRepository
  {

    private AppDbContext _context;
    private readonly ILoggerService _logger;

    public LiftTypeRepository(AppDbContext context, ILoggerService logger)
    {
      _context = context;
      _logger = logger;
    }

    public async Task<IEnumerable<LiftType>> GetAllAsync()
    {
      return await _context.LiftTypes.ToListAsync();
    }

    public async Task<LiftType> GetAsync(Guid id)
    {
      return await _context.LiftTypes.FindAsync(id);
    }

    public async Task<LiftType> CreateAsync(LiftType liftType)
    {
      try
      {
        await _context.LiftTypes.AddAsync(liftType);
      }
      catch (Exception ex)
      {
        // logging
        return liftType;
      }
      return liftType;
    }

    public async Task<LiftType> UpdateAsync(LiftType liftType)
    {
      try
      {
        _context.Entry(liftType).State = EntityState.Modified;
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        // logging
        return liftType;
      }
      return liftType;
    }

    public async Task<LiftType> DeleteAsync(Guid id)
    {
      var liftType = await _context.LiftTypes.FindAsync(id);
      if(liftType == null)
      {
        liftType.Status.Message = "Unable to find liftType";
        return liftType;
      }

      try
      {
        _context.LiftTypes.Remove(liftType);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        // logging
        return liftType;
      }
      return liftType;
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
