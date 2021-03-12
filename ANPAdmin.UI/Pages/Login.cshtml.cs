using ANPAdmin.Business;
using ANPAdmin.UI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ANPAdmin.UI.Pages
{
    public class LoginModel : PageModel
    {
        [Required]
        [BindProperty]
        public string Email { get; set; }
        [Required]
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {

        }

        private IAuth _auth;

        public LoginModel(IAuth auth)
        {
            _auth = auth;
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _auth.Login(Email, Password);

            if (user == null)
            {
                ModelState.AddModelError("INVALID_CREDENTIALS", "Usuário ou senha inválidos.");
                return Page();
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "USER_LOGIN", user);

            return RedirectToPage("./Index");
        }
    }
}