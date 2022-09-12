using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Domain;
using Market.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Market.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loginResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememderMe,
                lockoutOnFailure: false);
            if (!loginResult.Succeeded)
            {
                ModelState.AddModelError("", "Ошибка авторизации");
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName
            };
            var createResult = await _userManager.CreateAsync(user, model.Password);
            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(model);
                }
            }

            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
    }
}
