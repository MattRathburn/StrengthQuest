using Entities.Models;
using Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
  public class RoleRepository : IRoleRepository
  {

    private AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Role> GetAll()
    {
      return _context.Roles.ToList();
    }

    public Role GetById(int id)
    {
      return _context.Roles.Find(id);
    }

    public void Insert(Role role)
    {
      _context.Roles.Add(role);
    }

    public void Update(Role role)
    {
      _context.Entry(role).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      Role role = _context.Roles.Find(id);
      _context.Roles.Remove(role);
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
