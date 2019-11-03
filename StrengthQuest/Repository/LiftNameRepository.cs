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
  public class LiftNameRepository : ILiftNameRepository
  {

    private AppDbContext _context;

    public LiftNameRepository(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<LiftName> GetAll()
    {
      return _context.LiftNames.ToList();
    }

    public LiftName GetById(int id)
    {
      return _context.LiftNames.Find(id);
    }

    public void Insert(LiftName liftName)
    {
      _context.LiftNames.Add(liftName);
    }

    public void Update(LiftName liftName)
    {
      _context.Entry(liftName).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      LiftName liftName = _context.LiftNames.Find(id);
      _context.LiftNames.Remove(liftName);
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
