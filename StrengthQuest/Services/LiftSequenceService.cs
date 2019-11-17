using Contracts;
using Contracts.IServices;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class LiftSequenceService : ILiftSequenceService
  {

    private ILiftSequenceRepository _liftSequenceRepository;

    public LiftSequenceService(ILiftSequenceRepository liftSequenceRepository)
    {
      _liftSequenceRepository = liftSequenceRepository;
    }

    public async Task<LiftSequence> CreateAsync(LiftSequence lift)
    {
      return await _liftSequenceRepository.CreateAsync(lift);
    }

    public async Task<LiftSequence> DeleteAsync(Guid id)
    {
      return await _liftSequenceRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<LiftSequence>> GetAllAsync()
    {
      return await _liftSequenceRepository.GetAllAsync();
    }

    public async Task<LiftSequence> GetAsync(Guid id)
    {
      return await _liftSequenceRepository.GetAsync(id);
    }

    public async Task<LiftSequence> UpdateAsync(LiftSequence lift)
    {
      return await _liftSequenceRepository.UpdateAsync(lift);
    }
  }
}
