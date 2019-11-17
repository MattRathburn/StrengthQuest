using Entities.Models;
using Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository
{
  public class RoleRepository : IRoleRepository
  {

    private AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
      return await _context.Roles.ToListAsync();
    }

    public async Task<Role> GetAsync(Guid id)
    {
      try
      {
        return await _context.Roles.FindAsync(id);
      }
      catch (Exception ex)
      {
        // logging
        return null;
      }
    }

    public async Task<Role> CreateAsync(Role role)
    {
      try
      {
        await _context.Roles.AddAsync(role);
      }
      catch (Exception ex)
      {
        // Logging
        return role;
      }
      return role;
    }

    public async Task<Role> UpdateAsync(Role role)
    {
      try
      {
        _context.Entry(role).State = EntityState.Modified;
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        // logging
        return role;
      }
      return role;
    }

    public async Task<Role> DeleteAsync(Guid id)
    {
      var role = await _context.Roles.FindAsync(id);
      if(role == null)
      {
        role.Status.Message = "Unable to find Role";
        return role;
      }
      try
      {
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
      }
      catch(Exception ex)
      {
        // logging
        return role;
      }
      return role;
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
