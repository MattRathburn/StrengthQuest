using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.IServices
{
  public interface IUserBaseService<T>
  {
    List<T> GetAll(string uid);
    List<T> Get(Guid id, string uid);
    Task<T> CreateAsync(T type, string uid);
    Task<T> UpdateAsync(T type, string uid);
    Task<T> DeleteAsync(Guid id, string uid);
  }
}
