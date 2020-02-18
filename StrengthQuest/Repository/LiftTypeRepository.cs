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
    public class LiftTypeRepository : ILiftTypeRepository
    {

        private AppDbContext _context;
        private readonly ILoggerService _logger;

        public LiftTypeRepository(AppDbContext context, ILoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<LiftType> GetAll()
        {
            return _context.LiftTypes.ToList();
        }

        public LiftType Get(string id)
        {
            return _context.LiftTypes.Find(id);
        }

        public LiftType GetByName(string name)
        {
            return _context.LiftTypes.FirstOrDefault(n => n.Name == name);
        }

        public async Task<LiftType> CreateAsync(LiftType liftType)
        {
            try
            {
                await _context.LiftTypes.AddAsync(liftType);
            }
            catch (Exception ex)
            {
                // logging
                return liftType;
            }
            return liftType;
        }

        public async Task<LiftType> UpdateAsync(LiftType liftType)
        {
            try
            {
                _context.Entry(liftType).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // logging
                return liftType;
            }
            return liftType;
        }

        public async Task<LiftType> DeleteAsync(string id)
        {
            var liftType = await _context.LiftTypes.FindAsync(id);
            if (liftType == null)
            {
                return liftType;
            }

            try
            {
                _context.LiftTypes.Remove(liftType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // logging
                return liftType;
            }
            return liftType;
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
