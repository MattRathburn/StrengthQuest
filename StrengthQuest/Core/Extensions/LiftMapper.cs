using Entities.Models;
using System;
using ViewModels;

namespace Extensions
{
    public static class LiftMapper
    {
        public static LiftViewModel MapLiftToViewModel(Lift lift, string uid)
        {
            var vm = new LiftViewModel()
            {

                MaxLift = lift.MaxLift,
                IsMainLift = lift.IsMainLift,
                LiftName = lift.LiftName.Name,
                LiftType = lift.LiftType.Name,
                Date = lift.Date,
                Day = lift.Days.Day,
                Lift = new Lift()
                {
                    Id = lift.Id,
                    MaxLift = lift.MaxLift,
                    IsMainLift = lift.IsMainLift,
                    Date = lift.Date,
                    UserId = uid,
                    LiftName = new LiftName()
                    {
                        Id = lift.LiftName.Id
                    },
                    LiftType = new LiftType()
                    {
                        Id = lift.LiftType.Id
                    }
                }
            };
            return vm;
        }

        public static Lift MapViewModelToLift(LiftViewModel viewModel, string uid, LiftName liftName, LiftType liftType)
        {
            return new Lift()
            {
                Id = Guid.NewGuid().ToString(),
                MaxLift = viewModel.MaxLift,
                IsMainLift = viewModel.IsMainLift,
                Date = viewModel.Date,
                UserId = uid,
                LiftName = new LiftName()
                {
                    Id = liftName.Id
                },
                LiftType = new LiftType()
                {
                    Id = liftType.Id
                }
            };
        }
    }
}
