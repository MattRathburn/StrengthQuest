using Contracts;
using Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    public IEnumerable<User> GetAll()
    {
      return _context.Users.ToList();
    }

    public User GetById(int id)
    {
      return _context.Users.Find(id);
    }

    public void Insert(User user)
    {
      _context.Users.Add(user);
    }

    public void Update(User user)
    {
      _context.Entry(user).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
      User user = _context.Users.Find(id);
      _context.Users.Remove(user);
    }

    public void Save()
    {
      _context.SaveChanges();
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
