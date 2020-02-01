using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace Extensions
{
  public static class LiftMapper
  {
    public static LiftViewModel MapLiftToViewModel(Lift lift, LiftName liftName, LiftType liftType, string uid)
    {
      return new LiftViewModel()
      {

        MaxLift = lift.MaxLift,
        IsMainLift = lift.IsMainLift,
        LiftName = liftName.Name,
        LiftType = liftType.Name,
        Date = lift.Date,
        Lift = new Lift()
        {
          Id = lift.Id,
          MaxLift = lift.MaxLift,
          IsMainLift = lift.IsMainLift,
          Date = lift.Date,
          User = new User()
          {
            Id = uid
          },
          LiftName = new LiftName()
          {
            Id = liftName.Id
          },
          LiftType = new LiftType()
          {
            Id = liftType.Id
          }
        }
      };
    }

    public static Lift MapViewModelToLift(LiftViewModel viewModel, string uid, LiftName liftName, LiftType liftType)
    {
      return new Lift()
      {
        Id = Guid.NewGuid().ToString(),
        MaxLift = viewModel.MaxLift,
        IsMainLift = viewModel.IsMainLift,
        Date = viewModel.Date,
        User = new User()
        {
          Id = uid
        },
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
