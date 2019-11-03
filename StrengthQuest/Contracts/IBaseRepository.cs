using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
  public interface IBaseRepository<T> : IDisposable
  {
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Insert(T type);
    void Update(T type);
    void Delete(int id);
    void Save();
  }
}
