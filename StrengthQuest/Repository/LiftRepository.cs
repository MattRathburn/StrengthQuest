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
    public class LiftRepository : ILiftRepository
    {

        private readonly AppDbContext _context;
        private readonly ILoggerService _logger;

        public LiftRepository(AppDbContext context, ILoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Lift> GetLiftsByUserId(string uid)
        {
            // Use Eager Loading
            return _context.Lifts
              .Include(l => l.LiftName)
              .Include(t => t.LiftType)
              .Where(x => x.UserId == uid);
        }

        public IEnumerable<Lift> GetAll(string uid)
        {
            return _context.Lifts
              .Where(x => x.UserId == uid);
        }

        public Lift Get(string id, string uid)
        {
            return _context.Lifts
              .FirstOrDefault(x => x.UserId == uid && x.Id == id);
        }

        public async Task<Lift> CreateAsync(Lift lift)
        {
            try
            {
                await _context.Lifts.AddAsync(lift);
                return lift;
            }
            catch (Exception ex)
            {
                _logger.LogError($"-------------Error Creating Lift----------------");
                _logger.LogError($"{ex.Message}");
                _logger.LogError($"{ex.StackTrace}");
                return null;
            }
        }

        public async Task<Lift> UpdateAsync(Lift lift)
        {
            try
            {
                _context.Entry(lift).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"-------------Error updating Lift----------------");
                _logger.LogError($"{ex.Message}");
                _logger.LogError($"{ex.StackTrace}");
                return lift;
            }
            return lift;
        }

        public async Task<Lift> DeleteAsync(string id)
        {
            //  There needs to be a better way to return objects
            //  if something goes wrong

            var lift = await _context.Lifts.FindAsync(id);
            if (lift == null)
            {
                return lift;
            }

            try
            {
                _context.Lifts.Remove(lift);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // logging
                return lift;
            }
            return lift;
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
