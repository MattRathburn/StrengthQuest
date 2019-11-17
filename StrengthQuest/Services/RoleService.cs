using Contracts;
using Contracts.IServices;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class RoleService : IRoleService
  {

    private IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
      _roleRepository = roleRepository;
    }

    public async Task<Role> CreateAsync(Role role)
    {
      return await _roleRepository.CreateAsync(role);
    }

    public async Task<Role> DeleteAsync(Guid id)
    {
      return await _roleRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
      return await _roleRepository.GetAllAsync();
    }

    public async Task<Role> GetAsync(Guid id)
    {
      return await _roleRepository.GetAsync(id);
    }

    public async Task<Role> UpdateAsync(Role role)
    {
      return await _roleRepository.UpdateAsync(role);
    }
  }
}
