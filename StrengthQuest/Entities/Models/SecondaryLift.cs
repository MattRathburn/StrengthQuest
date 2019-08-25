using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
  public class SecondaryLift
  {
    [Key]
    public Guid Id { get; set; }

    public float MaxLift { get; set; }

    public User User { get; set; }

    public Lift Lift { get; set; }
  }
}
