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
    public class LiftSequenceRepository : ILiftSequenceRepository
    {

        private AppDbContext _context;
        private readonly ILoggerService _logger;

        public LiftSequenceRepository(AppDbContext context, ILoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<LiftSequence> GetAll(string uid)
        {
            return _context.LiftSequences
              .Where(x => x.UserId == uid);
        }

        public IEnumerable<LiftSequence> Get(string id, string uid)
        {
            return _context.LiftSequences
              .Where(x => x.UserId == uid)
              .Where(x => x.Id == id);
        }

        public async Task<LiftSequence> CreateAsync(LiftSequence liftSequence)
        {
            try
            {
                await _context.LiftSequences.AddAsync(liftSequence);
            }
            catch (Exception ex)
            {
                // logging
                return liftSequence;
            }
            return liftSequence;
        }

        public async Task<LiftSequence> UpdateAsync(LiftSequence liftSequence)
        {
            try
            {
                _context.Entry(liftSequence).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // logging
                return liftSequence;
            }
            return liftSequence;
        }

        public async Task<LiftSequence> DeleteAsync(string id)
        {

            var liftSequence = await _context.LiftSequences.FindAsync(id);
            if (liftSequence == null)
            {
                return liftSequence;
            }
            try
            {
                _context.LiftSequences.Remove(liftSequence);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // logging
                return liftSequence;
            }
            return liftSequence;
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
