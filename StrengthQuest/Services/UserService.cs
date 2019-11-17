using Contracts;
using Contracts.IServices;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class UserService : IUserService
  {

    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<User> CreateAsync(User user)
    {
      return await _userRepository.CreateAsync(user);
    }

    public async Task<User> DeleteAsync(Guid id)
    {
      return await _userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
      return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetAsync(Guid id)
    {
      return await _userRepository.GetAsync(id);
    }

    public async Task<User> UpdateAsync(User user)
    {
      return await _userRepository.UpdateAsync(user);
    }
  }
}
