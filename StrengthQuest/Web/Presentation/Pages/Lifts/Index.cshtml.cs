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
using ViewModels;
using Contracts;

namespace Presentation.Pages.Lifts
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILiftService _service;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoggerService _logger;

        public IndexModel(ILiftService service, UserManager<IdentityUser> userManager, ILoggerService logger)
        {
            _service = service;
            _userManager = userManager;
            _logger = logger;
        }

        public IList<LiftViewModel> LiftViewModel { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                LiftViewModel = _service.GetAll(user.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred.");
                _logger.LogError($"Message: {0}" + ex.Message);
            }
        }
    }
}
