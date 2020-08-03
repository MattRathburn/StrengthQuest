using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.IServices
{
  public interface IUserBaseService<T>
  {
    List<T> GetAll(string uid);
    //T Get(string id, string uid);
    Task<T> CreateAsync(T type, string uid);
    Task<T> UpdateAsync(T type, string uid);
    Task<T> DeleteAsync(string id, string uid);
  }
}
