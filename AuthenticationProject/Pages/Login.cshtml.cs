using AuthenticationProject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthenticationProject.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public Login Model { get; set; }

        public SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                var identityRes = await _signInManager.PasswordSignInAsync(Model.EmailId, Model.Password, false, false);
                if (identityRes.Succeeded)
                {
                    //if (returnUrl == null || returnUrl == "/")
                    //{
                    return RedirectToPage("Index");
                    //}
                    //else
                    //{
                    //    return RedirectToPage(returnUrl);
                    //}
                }
            }
            return Page();
        }
    }
}
