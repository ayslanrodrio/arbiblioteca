using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ARBiblioteca.Aplicacao;

namespace ARBiblioteca.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login, string senha)
        {
            var acessoAplicacao = new AcessoAplicacao();
            var usuarioLogado = acessoAplicacao.Logar(login, senha);
            if (usuarioLogado != null)
            {
                //autentica ele
                FormsAuthentication.SetAuthCookie(login, false);

                //Cria Variaveis Globais
                Session["Usuario"] = usuarioLogado;

                return RedirectToAction("Inicio");
            }

            ViewBag.Mensagem = "Login/Senha invalidos";
            return View();
        }

        [Authorize]//não precisa se estiver usando no controller
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            Session["Usuario"] = null;
            return RedirectToAction("Index");
        }

    }
}
