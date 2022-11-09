using AuthenticationProject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthenticationProject.Pages
{
    public class RoleModel : PageModel
    {
        [BindProperty]
        public AddRoleModel Model { get; set; }
        public RoleManager<IdentityRole> _roleManager;
        public RoleModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            IdentityRole role = await _roleManager.FindByIdAsync(Model.RoleName);

            if (role == null)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(Model.RoleName));
                if (result.Succeeded)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return Page();
        }
    }
}
