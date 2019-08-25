using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
  public class User : IdentityUser
  {
    public bool IsPound { get; set; }

    public ICollection<MainLift> MainLifts { get; set; }
    public ICollection<SecondaryLift> SecondaryLifts { get; set; }
  }
}
