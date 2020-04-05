using System.Threading.Tasks;
using app.Controllers.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            return View(loginViewModel);
        }
    }
}
