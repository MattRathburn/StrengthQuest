using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IRepositories
{
  public interface IUserBaseRepository<T> : IDisposable
  {
    IEnumerable<T> GetAll(string uid);
    IEnumerable<T> Get(Guid id, string uid);
    Task<T> CreateAsync(T type, string uid);
    Task<T> UpdateAsync(T type, string uid);
    Task<T> DeleteAsync(Guid id, string uid);
    Task<bool> SaveAsync();
  }
}
