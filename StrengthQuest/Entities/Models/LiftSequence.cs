using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
  public class LiftSequence
  {
    public int Id { get; set; }

    public int Sequence { get; set; }

    public User User { get; set; }

    public Lift Lift { get; set; }
  }
}
