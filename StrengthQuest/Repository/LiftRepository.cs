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
  public class LiftRepository : ILiftRepository
  {

    private AppDbContext _context;

    public LiftRepository(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Lift> GetAll()
    {
      return _context.Lifts.ToList();
    }

    public Lift GetById(int id)
    {
      return _context.Lifts.Find(id);
    }

    public void Insert(Lift lift)
    {
      _context.Lifts.Add(lift);
    }

    public void Update(Lift lift)
    {
      _context.Entry(lift).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      Lift lift = _context.Lifts.Find(id);
      _context.Lifts.Remove(lift);
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
