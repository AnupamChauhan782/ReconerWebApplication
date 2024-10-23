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
                    if (ChkEmail != null)
                    {
                        ModelState.AddModelError(string.Empty, "Email already exist");
                        return View(registarViewM);
                    }
                    var user=new IdentityUser
                    {
                        UserName=registarViewM.Email,
                        Email=registarViewM.Email

                    };
                    var result = await _userManager.CreateAsync(user, registarViewM.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    if (result.Errors.Count() > 0)
                    {
                        foreach(var err in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, err.Description);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(registarViewM);
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(loginViewM loginViewM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityUser checkEmail =await _userManager.FindByEmailAsync(loginViewM.Email);
                    if (checkEmail == null)
                    {
                        ModelState.AddModelError(string.Empty, "Email not found");
                        return View(loginViewM);
                    }
                    if(await _userManager.CheckPasswordAsync(checkEmail, loginViewM.Password) == false)
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Ceredentails");
                        return View(loginViewM);
                    }
                    var res = await _signInManager.PasswordSignInAsync(loginViewM.Email, loginViewM.Password, loginViewM.RememberMe, lockoutOnFailure: false);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }

            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");  // Changed from "Registar" to "Account"
        }
    }
}
