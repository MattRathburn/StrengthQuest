using Contracts;
using Contracts.IServices;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class LiftService : ILiftService
  {
    private ILiftRepository _liftRepository;

    public LiftService(ILiftRepository liftRepository)
    {
      _liftRepository = liftRepository;
    }

    public async Task<IEnumerable<Lift>> GetAllAsync()
    {
      return await _liftRepository.GetAllAsync();
    }

    public async Task<Lift> GetAsync(Guid id)
    {
      return await _liftRepository.GetAsync(id);
    }

    public async Task<Lift> CreateAsync(Lift lift)
    {
      return await _liftRepository.CreateAsync(lift);
    }

    public async Task<Lift> UpdateAsync(Lift lift)
    {
      return await _liftRepository.UpdateAsync(lift);
    }

    public async Task<Lift> DeleteAsync(Guid id)
    {
      return await _liftRepository.DeleteAsync(id);
    }
  }
}
