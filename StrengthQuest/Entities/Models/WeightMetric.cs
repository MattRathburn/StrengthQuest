using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
  public class WeightMetric
  {
    public int Id { get; set; }

    public bool IsPound { get; set; }

    public User User { get; set; }
  }
}
