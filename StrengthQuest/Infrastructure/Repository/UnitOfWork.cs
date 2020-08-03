using Contracts;
using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private LiftNameRepository _liftNameRepository;
        private LiftRepository _liftRepository;
        private LiftTypeRepository _liftTypeRepository;
        private WeightMetricRepository _weightMetricRepository;
        private ILoggerService _logger;

        public UnitOfWork(AppDbContext context, ILoggerService logger)
        {
            _context = context;
            _logger = logger;
        }

        public LiftNameRepository LiftNameRepository
        {
            get
            {
                if (_liftNameRepository == null)
                {
                    _liftNameRepository = new LiftNameRepository(_context, _logger);
                }
                return _liftNameRepository;
            }
        }

        public LiftRepository LiftRepository
        {
            get
            {
                if (_liftRepository == null)
                {
                    _liftRepository = new LiftRepository(_context, _logger);
                }
                return _liftRepository;
            }
        }

        public LiftTypeRepository LiftTypeRepository
        {
            get
            {
                if (_liftTypeRepository == null)
                {
                    _liftTypeRepository = new LiftTypeRepository(_context, _logger);
                }
                return _liftTypeRepository;
            }
        }

        public WeightMetricRepository WeightMetricRepository
        {
            get
            {
                if (_weightMetricRepository == null)
                {
                    _weightMetricRepository = new WeightMetricRepository(_context, _logger);
                }
                return _weightMetricRepository;
            }
        }

        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }

    }
}
