using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
  public class WeightMetric
  {
    public string Id { get; set; }

    public bool IsPound { get; set; }

    public virtual User User { get; set; }

  }
}
