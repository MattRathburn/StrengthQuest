using Contracts;
using Contracts.IRepositories;
using Contracts.IServices;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class LiftSequenceService : ILiftSequenceService
  {

    private readonly ILiftSequenceRepository _liftSequenceRepository;
    private readonly ILoggerService _logger;

    public LiftSequenceService(ILiftSequenceRepository liftSequenceRepository, ILoggerService logger)
    {
      _liftSequenceRepository = liftSequenceRepository;
      _logger = logger;
    }

    public async Task<LiftSequence> CreateAsync(LiftSequence lift, string uid)
    {
      return await _liftSequenceRepository.CreateAsync(lift, uid);
    }

    public async Task<LiftSequence> DeleteAsync(Guid id, string userId)
    {
      return await _liftSequenceRepository.DeleteAsync(id, userId);
    }

    public List<LiftSequence> GetAll(string userId)
    {
      return _liftSequenceRepository.GetAll(userId).ToList();
    }

    public List<LiftSequence> Get(Guid id, string userId)
    {
      return _liftSequenceRepository.Get(id, userId).ToList();
    }

    public async Task<LiftSequence> UpdateAsync(LiftSequence lift, string uid)
    {
      return await _liftSequenceRepository.UpdateAsync(lift, uid);
    }
  }
}
