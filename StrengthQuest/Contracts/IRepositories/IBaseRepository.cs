using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IRepositories
{
  public interface IBaseRepository<T> : IDisposable
  {
    IEnumerable<T> GetAll();
    T Get(string id);
    Task<T> CreateAsync(T type);
    Task<T> UpdateAsync(T type);
    Task<T> DeleteAsync(string id);
  }
}
