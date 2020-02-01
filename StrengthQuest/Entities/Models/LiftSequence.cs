using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
  public class LiftSequence
  {
    public string Id { get; set; }

    public int Sequence { get; set; }

    public virtual User User { get; set; }

    public virtual Lift Lift { get; set; }

  }
}
