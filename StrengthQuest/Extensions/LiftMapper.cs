using Entities.Models;
using System;
using ViewModels;

namespace Extensions
{
    public static class LiftMapper
    {
        public static LiftViewModel MapLiftToViewModel(Lift lift, string uid)
        {
            var trainingMax = MaxLiftCalculations.TrainingMax(lift.MaxLift);

            var vm = new LiftViewModel()
            {

                MaxLift = lift.MaxLift,
                TrainingMaxLift = trainingMax,
                Reps = lift.Reps,
                IsMainLift = lift.IsMainLift,
                LiftName = lift.LiftName.Name,
                LiftType = lift.LiftType.Name,
                Date = lift.Date,
                LiftId = lift.Id,
                Set1 = RepCalculations.CalculateReps(trainingMax, 0.75),
                Set2 = RepCalculations.CalculateReps(trainingMax, 0.85),
                Set3 = RepCalculations.CalculateReps(trainingMax, 0.95),
                Set4 = RepCalculations.CalculateReps(trainingMax, 0.9),
                Set5 = RepCalculations.CalculateReps(trainingMax, 0.85),
                Set6 = RepCalculations.CalculateReps(trainingMax, 0.8),
                Set7 = RepCalculations.CalculateReps(trainingMax, 0.75),
                Set8 = RepCalculations.CalculateReps(trainingMax, 0.7),
            };
            return vm;
        }

        public static Lift MapViewModelToLift(LiftViewModel viewModel, string uid, LiftName liftName, LiftType liftType)
        {
            return new Lift()
            {
                Id = viewModel.LiftId,
                MaxLift = viewModel.MaxLift,
                Reps = viewModel.Reps,
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
