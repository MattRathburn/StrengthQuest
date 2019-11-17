using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
  public class LiftSequence
  {
    public Guid Id { get; set; }

    public int Sequence { get; set; }

    public User User { get; set; }

    public Lift Lift { get; set; }

    [NotMapped]
    public ReturnStatus Status { get; set; }
  }
}
