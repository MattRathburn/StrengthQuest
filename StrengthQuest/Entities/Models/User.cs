using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
  public class User : IdentityUser
  {
    public ICollection<Lift> Lifts { get; set; }

    [NotMapped]
    public ReturnStatus Status { get; set; }
  }
}
