using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelData.ViewModel;

namespace ReCornerApplication.Controllers.Auth
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser>signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Registar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registar(RegistarViewM registarViewM)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var ChkEmail=await _userManager.FindByEmailAsync(registarViewM.Email);
                    if (ChkEmail == null)
                    {
                        ModelState.AddModelError(string.Empty, "Email already exist");
                        return View(registarViewM);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View(registarViewM);
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
