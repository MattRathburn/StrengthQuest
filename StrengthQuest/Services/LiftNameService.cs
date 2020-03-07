using Contracts;
using Contracts.IRepositories;
using Contracts.IServices;
using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<LiftName> DeleteAsync(string id)
        {
            return await _liftNameRepository.DeleteAsync(id);
        }

        public List<LiftName> GetAll()
        {
            return _liftNameRepository.GetAll().ToList();
        }

        public SelectList GetAllToSelectList()
        {
            var liftNames = _liftNameRepository.GetAll();

            return new SelectList(liftNames, "Id", "Name");
        }

        public LiftName Get(string id)
        {
            return _liftNameRepository.Get(id);
        }

        public async Task<LiftName> UpdateAsync(LiftName liftName)
        {
            return await _liftNameRepository.UpdateAsync(liftName);
        }
    }
}
