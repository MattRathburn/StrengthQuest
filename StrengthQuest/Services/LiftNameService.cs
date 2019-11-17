using Contracts;
using Contracts.IServices;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class LiftNameService : ILiftNameService
  {

    private ILiftNameRepository _liftNameRepository;

    public LiftNameService(ILiftNameRepository liftNameRepository)
    {
      _liftNameRepository = liftNameRepository;
    }

    public async Task<LiftName> CreateAsync(LiftName liftName)
    {
      return await _liftNameRepository.CreateAsync(liftName);
    }

    public async Task<LiftName> DeleteAsync(Guid id)
    {
      return await _liftNameRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LiftName>> GetAllAsync()
    {
      return await _liftNameRepository.GetAllAsync();
    }

    public async Task<LiftName> GetAsync(Guid id)
    {
      return await _liftNameRepository.GetAsync(id);
    }

    public async Task<LiftName> UpdateAsync(LiftName liftName)
    {
      return await _liftNameRepository.UpdateAsync(liftName);
    }
  }
}
