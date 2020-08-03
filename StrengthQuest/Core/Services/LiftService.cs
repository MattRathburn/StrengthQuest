using Contracts;
using Contracts.IRepositories;
using Contracts.IServices;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ViewModels;
using Extensions;

namespace Services
{
    public class LiftService : ILiftService
    {
        private readonly ILiftRepository _liftRepository;
        private readonly ILiftNameRepository _liftNameRepository;
        private readonly ILiftTypeRepository _liftTypeRepository;
        private readonly ILoggerService _logger;

        public LiftService(ILiftRepository liftRepository, ILiftNameRepository liftNameRepository, ILiftTypeRepository liftTypeRepository, ILoggerService logger)
        {
            _liftRepository = liftRepository;
            _liftNameRepository = liftNameRepository;
            _liftTypeRepository = liftTypeRepository;
            //_liftMapper = liftMapper;
            _logger = logger;
        }

        public List<LiftViewModel> GetAll(string uid)
        {
            try
            {
                var lifts = _liftRepository.GetAll(uid).ToList();
                DaysService ds = new DaysService();

                List<LiftViewModel> viewModel = new List<LiftViewModel>();

                foreach (Lift lift in lifts)
                {
                    viewModel.Add(LiftMapper.MapLiftToViewModel(lift, uid));
                      //liftNames.FirstOrDefault(x => x.Id == l.LiftName.Id),
                      //liftTypes.FirstOrDefault(x => x.Id == l.LiftType.Id),
                      //uid));
                }

                return viewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Inner Exception: {0}" + ex.InnerException);
            }
            return null;
        }

        public LiftViewModel Get(string id, string uid)
        {

            Lift lift = _liftRepository.Get(id, uid);
            LiftName liftName = _liftNameRepository.Get(lift.LiftName.Id);
            LiftType liftType = _liftTypeRepository.Get(lift.LiftType.Id);

            LiftViewModel viewModel = LiftMapper.MapLiftToViewModel(lift, uid);//,
                //liftName,
                //liftType,
                //uid);

            return viewModel;
        }

        public async Task<LiftViewModel> CreateAsync(LiftViewModel viewModel, string uid)
        {
            /*
             * Create lift and call GetAll to retrieve the updated lifts 
             * - Add DaysService call to change Id (int) to String (day)
             */
            LiftName liftName = _liftNameRepository.GetByName(viewModel.LiftName);
            LiftType liftType = _liftTypeRepository.GetByName(viewModel.LiftType);
            Lift lift = LiftMapper.MapViewModelToLift(viewModel, uid, liftName, liftType);
            lift = await _liftRepository.CreateAsync(lift, uid);
            return LiftMapper.MapLiftToViewModel(lift, uid);//, liftName, liftType, uid);
        }

        public async Task<LiftViewModel> UpdateAsync(LiftViewModel lift, string uid)
        {
            /*
            * Update lift and call GetAll to retrieve the updated lifts 
            */
            //var vm = new LiftViewModel();
            Lift l = _liftRepository.Get(lift.Lift.Id, uid);
            LiftName liftName = _liftNameRepository.GetByName(lift.LiftName);
            LiftType liftType = _liftTypeRepository.GetByName(lift.LiftType);
            var updatedLift = await _liftRepository.UpdateAsync(l, uid);
            return LiftMapper.MapLiftToViewModel(updatedLift, uid);//, liftName, liftType, uid);

        }

        public async Task<LiftViewModel> DeleteAsync(string id, string uid)
        {
            /*
            * Delete lift and call GetAll to retrieve the updated lifts 
            */
            //return await _liftRepository.DeleteAsync(id, uid);
            return null;
        }
    }
}
