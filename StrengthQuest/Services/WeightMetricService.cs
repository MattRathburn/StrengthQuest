using Contracts;
using Contracts.IServices;
using Entities.Models;
using System;
using System.Collections.Generic;
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

    public async Task<WeightMetric> CreateAsync(WeightMetric metric)
    {
      return await _weightMetricRepository.CreateAsync(metric);
    }

    public async Task<WeightMetric> DeleteAsync(Guid id)
    {
      return await _weightMetricRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<WeightMetric>> GetAllAsync()
    {
      return await _weightMetricRepository.GetAllAsync();
    }

    public async Task<WeightMetric> GetAsync(Guid id)
    {
      return await _weightMetricRepository.GetAsync(id);
    }

    public async Task<WeightMetric> UpdateAsync(WeightMetric metric)
    {
      return await _weightMetricRepository.UpdateAsync(metric);
    }
  }
}
