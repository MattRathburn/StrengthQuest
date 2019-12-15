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
  public class LiftNameService : ILiftNameService
  {

    private readonly ILiftNameRepository _liftNameRepository;
    private readonly ILoggerService _logger;

    public LiftNameService(ILiftNameRepository liftNameRepository, ILoggerService logger)
    {
      _liftNameRepository = liftNameRepository;
      _logger = logger;
    }

    public async Task<LiftName> CreateAsync(LiftName liftName)
    {
      return await _liftNameRepository.CreateAsync(liftName);
    }

    public async Task<LiftName> DeleteAsync(Guid id)
    {
      return await _liftNameRepository.DeleteAsync(id);
    }

    public List<LiftName> GetAll()
    {
      return _liftNameRepository.GetAll().ToList();
    }

    public LiftName Get(Guid id)
    {
      return _liftNameRepository.Get(id);
    }

    public async Task<LiftName> UpdateAsync(LiftName liftName)
    {
      return await _liftNameRepository.UpdateAsync(liftName);
    }
  }
}
