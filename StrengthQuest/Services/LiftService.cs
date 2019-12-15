using Contracts;
using Contracts.IRepositories;
using Contracts.IServices;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Services
{
  public class LiftService : ILiftService
  {
    private readonly ILiftRepository _liftRepository;
    private readonly ILoggerService _logger;

    public LiftService(ILiftRepository liftRepository, ILoggerService logger)
    {
      _liftRepository = liftRepository;
      _logger = logger;
    }

    public List<Lift> GetAll(string uid)
    {
      return _liftRepository.GetAll(uid).ToList();
    }

    public List<Lift> Get(Guid id, string uid)
    {
      return _liftRepository.Get(id, uid).ToList();
    }

    public async Task<Lift> CreateAsync(Lift lift, string uid)
    {
      return await _liftRepository.CreateAsync(lift, uid);
    }

    public async Task<Lift> UpdateAsync(Lift lift, string uid)
    {
      return await _liftRepository.UpdateAsync(lift, uid);
    }

    public async Task<Lift> DeleteAsync(Guid id, string uid)
    {
      return await _liftRepository.DeleteAsync(id, uid);
    }
  }
}
