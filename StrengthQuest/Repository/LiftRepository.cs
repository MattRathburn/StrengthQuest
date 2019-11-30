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
  public class LiftRepository : ILiftRepository
  {

    private readonly AppDbContext _context;
    private readonly ILoggerService _logger;

    public LiftRepository(AppDbContext context, ILoggerService logger)
    {
      _context = context;
      _logger = logger;
    }

    public async Task<IEnumerable<Lift>> GetAllAsync()
    {
      return await _context.Lifts.ToListAsync();
    }

    public async Task<Lift> GetAsync(Guid id)
    {
      return await _context.Lifts.FindAsync(id);
    }

    public async Task<Lift> CreateAsync(Lift lift)
    {
      try
      {
        await _context.Lifts.AddAsync(lift);
      }
      catch (Exception ex)
      {
        _logger.LogError($"-------------Error Creating Lift----------------");
        _logger.LogError($"{ex.Message}");
        _logger.LogError($"{ex.StackTrace}");
        lift.Status.Message = $"An error occurred while creating lift: {lift.LiftName.Name}";
        return lift;
      }
      return lift;
      
    }

    public async Task<Lift> UpdateAsync(Lift lift)
    {
      try
      {
        _context.Entry(lift).State = EntityState.Modified;
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        _logger.LogError($"-------------Error updating Lift----------------");
        _logger.LogError($"{ex.Message}");
        _logger.LogError($"{ex.StackTrace}");
        return lift;
      }
      return lift;
    }

    public async Task<Lift> DeleteAsync(Guid id)
    {
      //  There needs to be a better way to return objects
      //  if something goes wrong

      var lift = await _context.Lifts.FindAsync(id);
      if (lift == null)
      {
        lift.Status.Message = "Unable to find lift";
        return lift;
      }

      try
      {
        _context.Lifts.Remove(lift);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        // logging
        lift.Status.Message = "An error occurred while deleting lift";
        return lift;
      }
      return lift;
    }

    public async Task<bool> SaveAsync()
    {
      try
      {
        await _context.SaveChangesAsync();
      }
      catch(Exception ex)
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
