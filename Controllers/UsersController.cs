using Microsoft.AspNetCore.Mvc;
using Tools.Data;
using Tools.Models;

using Microsoft.AspNetCore.Authorization;

namespace Tools.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        UsersData oUsersData = new();
        public IActionResult List()
        {
            var oLista = oUsersData.FetchUsers();
            return View(oLista);
        }
        public IActionResult NewOrEdit(int? oUserIdContacto)
        {
            if (!oUserIdContacto.HasValue || oUserIdContacto.Value == 0)
            {
                return View("NewOrEdit", new UsersModel());
            }
            var ouser = oUsersData.FetchUser(oUserIdContacto.Value);
            if (ouser == null)
            {
                return NotFound();
            }
            return View("NewOrEdit", ouser);
        }
        [HttpPost]
        public IActionResult NewOrEdit(UsersModel oUser)
        {
            if (!ModelState.IsValid)
            {
                return oUser.Id == 0 ? View("NewOrEdit", oUser) : View("NewOrEdit", oUser);
            }
            bool result;
            if (oUser.Id == 0)
            {
                result = oUsersData.NewUser(oUser);
            }
            else
            {
                result = oUsersData.UpdateUser(oUser);
            }
            if (result)
            {
                return RedirectToAction("List");
            }
            return oUser.Id == 0 ? View("NewOrEdit", oUser) : View("NewOrEdit", oUser);
        }
        public IActionResult Delete(int oUserIdContacto)
        {
            var ouser = oUsersData.FetchUser(oUserIdContacto);
            return View(ouser);
        }
        [HttpPost]
        public IActionResult Delete(UsersModel oUser)
        {
            var ouser = oUsersData.DeleteUser(oUser.Id);
            if (ouser)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }
    }
}
