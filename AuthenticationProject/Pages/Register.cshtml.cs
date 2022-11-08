using AuthenticationProject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthenticationProject.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Register Model { get; set; }

        public UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signInManager;

        public RegisterModel(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager=userManager;  
            _signInManager=signInManager;
        }
        public void OnGet()
        {
        }
        public async Task <IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.EmailId,
                    Email = Model.EmailId
                };
                var result = await _userManager.CreateAsync(user, Model.Password); 
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user,false);
                    RedirectToAction("Index");
                }
                else
                {
                    RedirectToAction("Index");
                }
               //var result = Model;
            }
            return Page();
        }
    }
}
