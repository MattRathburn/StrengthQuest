using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Contracts.IRepositories;
using Contracts.IServices;
using Entities.Models;

namespace Services
{
    public class LiftTypeService : ILiftTypeService
    {

        private readonly ILiftTypeRepository _liftTypeRepository;
        private readonly ILoggerService _logger;

        public LiftTypeService(ILiftTypeRepository liftTypeRepository, ILoggerService logger)
        {
            _liftTypeRepository = liftTypeRepository;
            _logger = logger;
        }

        public async Task<LiftType> CreateAsync(LiftType lift)
        {
            return await _liftTypeRepository.CreateAsync(lift);
        }

        public async Task<LiftType> DeleteAsync(string id)
        {
            return await _liftTypeRepository.DeleteAsync(id);
        }

        public List<LiftType> GetAll()
        {
            return _liftTypeRepository.GetAll().ToList();
        }

        public LiftType Get(string id)
        {
            return _liftTypeRepository.Get(id);
        }

        public async Task<LiftType> UpdateAsync(LiftType lift)
        {
            return await _liftTypeRepository.UpdateAsync(lift);
        }
    }
}
