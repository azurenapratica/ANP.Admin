using ANPAdmin.UI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ANPAdmin.UI.Controllers
{
    public class ContaController : ControllerBase
    {
        [HttpGet("sair")]
        public IActionResult Sair()
        {
            SessionHelper.ClearSession(HttpContext.Session);
            return RedirectToPage("/login");
        }
    }
}
