using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Contracts.IServices;
using Entities.Models;

namespace Services
{
  public class LiftTypeService : ILiftTypeService
  {

    private ILiftTypeRepository _liftTypeRepository;

    public LiftTypeService(ILiftTypeRepository liftTypeRepository)
    {
      _liftTypeRepository = liftTypeRepository;
    }

    public async Task<LiftType> CreateAsync(LiftType lift)
    {
      return await _liftTypeRepository.CreateAsync(lift);
    }

    public async Task<LiftType> DeleteAsync(Guid id)
    {
      return await _liftTypeRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LiftType>> GetAllAsync()
    {
      return await _liftTypeRepository.GetAllAsync();
    }

    public async Task<LiftType> GetAsync(Guid id)
    {
      return await _liftTypeRepository.GetAsync(id);
    }

    public async Task<LiftType> UpdateAsync(LiftType lift)
    {
      return await _liftTypeRepository.UpdateAsync(lift);
    }
  }
}
