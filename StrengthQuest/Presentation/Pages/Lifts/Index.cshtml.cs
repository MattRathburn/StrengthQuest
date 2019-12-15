using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Contracts.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Presentation.Pages.Lifts
{
  [Authorize]
  public class IndexModel : PageModel
  {
    private readonly ILiftService _service;
    private readonly UserManager<IdentityUser> _userManager;

    public IndexModel(ILiftService service, UserManager<IdentityUser> userManager)
    {
      _service = service;
      _userManager = userManager;
    }

    public List<Lift> Lift { get; set; }

    public async Task OnGetAsync()
    {
      try
      {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        Lift = _service.GetAll(user.Id);
      }
      catch(Exception ex)
      {
        // logging
      }      
    }
  }
}
