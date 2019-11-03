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
  public class LiftSequenceRepository : ILiftSequenceRepository
  {

    private AppDbContext _context;

    public LiftSequenceRepository(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<LiftSequence> GetAll()
    {
      return _context.LiftSequences.ToList();
    }

    public LiftSequence GetById(int id)
    {
      return _context.LiftSequences.Find(id);
    }

    public void Insert(LiftSequence liftSequence)
    {
      _context.LiftSequences.Add(liftSequence);
    }

    public void Update(LiftSequence liftSequence)
    {
      _context.Entry(liftSequence).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      LiftSequence liftSequence = _context.LiftSequences.Find(id);
      _context.LiftSequences.Remove(liftSequence);
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
