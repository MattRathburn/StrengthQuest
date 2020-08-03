using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.Pages
{
  public class AboutModel : PageModel
  {
    public string Message { get; set; }

    public void OnGet()
    {
      Message = "Strength Quest provides lifters with a tool to track their progress with the nSuns 531 variant.";
    }
  }
}
