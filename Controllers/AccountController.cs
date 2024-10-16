using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Domain;
using System.Security.Claims;

namespace LibraryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous] // Allows users to access the login page without being authenticated.
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous] // Allows users to access the login page without being authenticated.
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                // Replace this with your actual authentication logic
                bool isValidUser = model.Username == "admin" && model.Password == "password";

                if (isValidUser)
                {
                    // Create the user identity and sign in
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username)
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true // This will keep the user logged in across sessions
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }

        [Authorize] // Only authenticated users can log out.
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
