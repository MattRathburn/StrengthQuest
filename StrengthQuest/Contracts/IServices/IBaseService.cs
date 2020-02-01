using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.IServices
{
  public interface IBaseService<T>
  {
    List<T> GetAll();
    T Get(string id);
    Task<T> CreateAsync(T type);
    Task<T> UpdateAsync(T type);
    Task<T> DeleteAsync(string id);
  }
}
