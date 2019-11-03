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
  public class LiftTypeRepository : ILiftTypeRepository
  {

    private AppDbContext _context;

    public LiftTypeRepository(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<LiftType> GetAll()
    {
      return _context.LiftTypes.ToList();
    }

    public LiftType GetById(int id)
    {
      return _context.LiftTypes.Find(id);
    }

    public void Insert(LiftType liftType)
    {
      _context.LiftTypes.Add(liftType);
    }

    public void Update(LiftType liftType)
    {
      _context.Entry(liftType).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      LiftType liftType = _context.LiftTypes.Find(id);
      _context.LiftTypes.Remove(liftType);
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
