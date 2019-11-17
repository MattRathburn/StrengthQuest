using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
  public class WeightMetric
  {
    public Guid Id { get; set; }

    public bool IsPound { get; set; }

    public User User { get; set; }

    [NotMapped]
    public ReturnStatus Status { get; set; }
  }
}
