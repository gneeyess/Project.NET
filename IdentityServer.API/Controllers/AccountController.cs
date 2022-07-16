using Dal.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace IdentityServer.API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Log.Information("AccountController constructed");
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }

        // POST: /Account/Register
        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] User user_model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = user_model.Email,
                    FirstName = user_model.FirstName,
                    LastName = user_model.LastName,
                    Email = user_model.Email,
                    PhoneNumber = user_model.PhoneNumber,
                    PasswordHash = user_model.PasswordHash
                };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                    return Ok();
                    //// установка куки
                    await _signInManager.SignInAsync(user, false);
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            Log.Information("AccountController.Register()");
            return Ok();
        }
    }
}