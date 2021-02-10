using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizzaorder.Models;
using Microsoft.AspNetCore.Identity;

namespace Pizzaorder.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signinManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                string uname = User.Identity.Name;

                //ViewBag.msg = $" {uname},Login is successful";
                return RedirectToAction("Index", "PizzaOrder");
            }
            else
            {
                ViewBag.msg = "Failed to login";
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            IdentityUser User = new IdentityUser { UserName = model.Email, Email = model.Email };
            IdentityResult result = await _userManager.CreateAsync(User, model.Password);
            if (result.Succeeded)
            {
                ViewBag.msg = "User Created Successfully";
            }
            else
            {
                ViewBag.msg = "Failed to create";
            }
            return RedirectToAction("Login","Account");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await _signinManager.SignOutAsync();
            ViewBag.msg = "User logged out successfully";
            return View();
        }

    }
}
