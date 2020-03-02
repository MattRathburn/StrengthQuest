using Contracts;
using Contracts.IRepositories;
using Data;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WeightMetricRepository : IWeightMetricRepository
    {

        private AppDbContext _context;
        private readonly ILoggerService _logger;

        public WeightMetricRepository(AppDbContext context, ILoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<WeightMetric> GetAll(string uid)
        {
            try
            {
                return _context.WeightMetrics
                  .Where(x => x.UserId == uid);
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get Weight Metric");
                _logger.LogError($"{ex.Message}");
                return null;
            }
        }

        public async Task<WeightMetric> Get(string uid)
        {
            try
            {
                WeightMetric wm = await _context.WeightMetrics
                  .FirstOrDefaultAsync(w => w.UserId == uid);
                return wm;
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't get Weight Metric");
                _logger.LogError($"{ex.Message}");
                return null;
            }
        }

        public async Task<WeightMetric> CreateAsync(WeightMetric weightMetric, string uid)
        {
            try
            {
                await _context.WeightMetrics.AddAsync(weightMetric);
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't create Weight Metric");
                _logger.LogError($"{ex.Message}");
                return weightMetric;
            }
            return weightMetric;
        }

        public async Task<WeightMetric> UpdateAsync(WeightMetric weightMetric, string uid)
        {
            try
            {
                _context.Entry(weightMetric).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't update Weight Metric");
                _logger.LogError($"{ex.Message}");
                return weightMetric;
            }
            return weightMetric;
        }

        public async Task<WeightMetric> DeleteAsync(string id, string uid)
        {
            var weightMetric = await _context.WeightMetrics.FindAsync(id);
            if (weightMetric == null)
            {
                return weightMetric;
            }
            try
            {
                _context.WeightMetrics.Remove(weightMetric);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Couldn't delete Weight Metric");
                _logger.LogError($"{ex.Message}");
                return weightMetric;
            }
            return weightMetric;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
