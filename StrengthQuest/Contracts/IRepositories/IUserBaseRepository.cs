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
    //T Get(string id, string uid);
    Task<T> CreateAsync(T type);
    Task<T> UpdateAsync(T type);
    Task<T> DeleteAsync(string id);
  }
}
