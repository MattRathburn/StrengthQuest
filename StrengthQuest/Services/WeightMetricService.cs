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
  public class WeightMetricService : IWeightMetricService
  {

    private readonly IWeightMetricRepository _weightMetricRepository;
    private readonly ILoggerService _logger;

    public WeightMetricService(IWeightMetricRepository weightMetricRepository, ILoggerService logger)
    {
      _weightMetricRepository = weightMetricRepository;
      _logger = logger;
    }

    public async Task<WeightMetric> CreateAsync(WeightMetric metric, string uid)
    {
      return await _weightMetricRepository.CreateAsync(metric, uid);
    }

    public async Task<WeightMetric> DeleteAsync(Guid id, string uid)
    {
      return await _weightMetricRepository.DeleteAsync(id, uid);
    }

    public List<WeightMetric> GetAll(string uid)
    {
      return _weightMetricRepository.GetAll(uid).ToList();
    }

    public List<WeightMetric> Get(Guid id, string uid)
    {
      return _weightMetricRepository.Get(id, uid).ToList();
    }

    public async Task<WeightMetric> UpdateAsync(WeightMetric metric, string uid)
    {
      return await _weightMetricRepository.UpdateAsync(metric, uid);
    }
  }
}
