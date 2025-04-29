using System.Security.Claims;
using MVCPeliculas.BasedeDatosFisticia;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MVCPeliculas.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(string username, string password)
        {
            var user = FakeUserDB.Users.FirstOrDefault(u => u.User == username && u.Password == password);
            if (user != null)
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, username)
                             };

                HttpContext.Session.SetString("User", user.User);
                var indentity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(indentity);

                HttpContext.SignInAsync("Cookies", principal);
                return RedirectToAction("Index", "Home");


                
            }
            else
            {
                ViewBag.Error = "Credenciles Invalidas";

            }


            return View();

        }
        

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync("cookies");
            return RedirectToAction("Login");

        }
    } 
}
