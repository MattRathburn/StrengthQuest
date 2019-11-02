using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
  public class Lift
  {
    [Key]
    public Guid Id { get; set; }

    public float MaxLift { get; set; }

    public bool IsMainLift { get; set; }

    public User User { get; set; }

    public LiftName LiftName { get; set; }

    public LiftType LiftType { get; set; }
  }
}
