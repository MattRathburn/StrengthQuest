using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
  public class Role : IdentityRole
  {

    public string Description { get; set; }

    public Role()
    {

    }

    public Role(string roleName, string description) : base(roleName)
    {
      this.Description = description;
    }

  }
}
