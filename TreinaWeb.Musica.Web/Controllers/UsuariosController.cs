using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.Musica.Servicos.Entity.Context;
using TreinaWeb.Musica.Web.Identity;
using TreinaWeb.Musica.Web.ViewModels.Usuario;

namespace TreinaWeb.Musica.Web.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult CadastrarUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarUsuario(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicasIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var identityUser = new IdentityUser()
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };
                IdentityResult resultado = userManager.Create(identityUser, viewModel.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("identity_error", resultado.Errors.First());
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }
    }
}