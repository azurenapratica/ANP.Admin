using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ANPAdmin.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("USER_LOGIN") == null)
            {
                await Task.Run(() => { });
                return RedirectToPage("login");
            }

            return Page();
        }
    }
}
