using System.Threading.Tasks;
using DotNETDay2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNETDay2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        // Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisteraccountViewModel newAccount)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.UserName;
                user.Email = newAccount.Email;
                IdentityResult Result = await userManager.CreateAsync(user, newAccount.password);
                if (Result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Showinstructor", "instructor");
                }
                foreach (var item in Result.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View(newAccount);
        }
        /* -----------------------------------------Login--------------------------
        */
        public IActionResult Login(string ReturnUrl = "~/instructor/ShowInstructor")
        {
            ViewData["RedirectURL"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginUser, string ReturnUrl = "~/instructor/ShowInstructor")
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginUser.UserName);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult
                        result = await signInManager.PasswordSignInAsync(user, loginUser.Password, loginUser.rememberMe,false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "invalid user name & password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "invalid username ,password");
                }
            }
            return View(loginUser);
        }
        /* -----------------------------------------Logout--------------------------
        */
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        /*------------------------------------------add role admin---------------------
          */

        public IActionResult AddAdmin()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Addadmin(RegisteraccountViewModel newAccount)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.UserName;
                user.Email = newAccount.Email;
                IdentityResult Result = await userManager.CreateAsync(user, newAccount.password);
                if (Result.Succeeded)
                {
                    //add to admin role 
                    await userManager.AddToRoleAsync(user, "Admin");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Showinstructor", "instructor");
                }
                foreach (var item in Result.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View("Register", newAccount);
        }


    }
}