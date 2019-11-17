using Contracts;
using Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
  public class UserRepository : IUserRepository
  {

    private AppDbContext _context;
    private bool _disposed = false;

    public UserRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task<User> GetAsync(Guid id)
    {
      try
      {
        return await _context.Users.FindAsync(id);
      }
      catch (Exception ex)
      {
        // logging
        return null;
      }

    }

    public async Task<User> CreateAsync(User user)
    {
      try
      {
        await _context.Users.AddAsync(user);
      }
      catch (Exception ex)
      {
        // logging
        return user;
      }
      return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
      try
      {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        // logging
        return user;
      }
      return user;
    }

    public async Task<User> DeleteAsync(Guid id)
    {
      var user = await _context.Users.FindAsync(id);
      if(user == null)
      {
        user.Status.Message = "Unable to find User";
        return user;
      }

      try
      {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
      }
      catch(Exception ex)
      {
        // logging
        return user;
      }
      return user;
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

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      this._disposed = true;
    }
  }
}
