using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
  public class LiftName
  {
    public Guid Id { get; set; }

    public string Name { get; set; }

    [NotMapped]
    public ReturnStatus Status { get; set; }
  }
}
