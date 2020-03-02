using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
  public class User : IdentityUser
  {
    public virtual IEnumerable<Lift> Lifts { get; set; }

  }
}
