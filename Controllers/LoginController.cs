using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tools.Data;
using Tools.Models;

namespace Tools.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("List", "Users");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UsersModel oUser)
        {
            UsersData _da_usuario = new();
            if (oUser.Email == null || oUser.Password == null)
            {
                return View();
            }
            else if (oUser.Email.Trim() == "" || oUser.Password.Trim() == "")
            {
                return View();
            }
            else
            {
                var usuario = _da_usuario.ValidateUser(oUser.Email, oUser.Password);
                if (usuario != null && usuario.Email != null && usuario.Username != null && usuario.Roles != null && usuario.Nombre != null && usuario.Apellidos != null)
                {
                   var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Nombre + " " + usuario.Apellidos),
                        new Claim(ClaimTypes.Email, usuario.Email),
                    };
                    foreach (string rol in usuario.Roles.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol.Trim()));
                    }
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("List", "Users");
                }
                else
                {
                    return View();
                }
            }

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
