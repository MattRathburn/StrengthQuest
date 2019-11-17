using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
  public interface IBaseRepository<T> : IDisposable
  {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task<T> CreateAsync(T type);
    Task<T> UpdateAsync(T type);
    Task<T> DeleteAsync(Guid id);
    Task<bool> SaveAsync();
  }
}
