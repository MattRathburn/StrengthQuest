using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data;
using Entities.Models;
using Contracts.IServices;
using Microsoft.Extensions.Options;
using ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Presentation.Pages.Lifts
{
    public class CreateModel : PageModel
    {

        private readonly ILiftService _liftService;
        private readonly ILiftTypeService _liftTypeService;
        private readonly ILiftNameService _liftNameService;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ILiftService liftService, ILiftTypeService liftTypeService, ILiftNameService liftNameService, UserManager<IdentityUser> userManager)
        {
            _liftService = liftService;
            _liftTypeService = liftTypeService;
            _liftNameService = liftNameService;
            _userManager = userManager;
        }

        public SelectList LiftNames { get; set; }
        public SelectList LiftTypes { get; set; }

        public IActionResult OnGet()
        {
            var names = _liftNameService.GetAll();
            var types = _liftTypeService.GetAll();

            LiftNames = new SelectList(names, "Id", "Name");
            LiftTypes = new SelectList(types, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public LiftViewModel Lift { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Lifts.Add(Lift);
            //await _context.SaveChangesAsync();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _liftService.CreateAsync(Lift, user.Id);

            return RedirectToPage("./Index");
        }
    }
}