using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARBiblioteca.Aplicacao;
using ARBiblioteca.Dominio;

namespace ARBiblioteca.UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            var usuarioAplicacao = new UsuarioAplicacao();
            return View(usuarioAplicacao.ListarTodos());
        }

        public ActionResult Detalhes(int id)
        {
            var usuarioAplicacao = new UsuarioAplicacao();
            var usuario = usuarioAplicacao.ListarPorId(id);
            if (usuario == null)
                return HttpNotFound();
            return View(usuario);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioAplicacao = new UsuarioAplicacao();
                usuarioAplicacao.Salvar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Editar(int id)
        {
            var usuarioAplicacao = new UsuarioAplicacao();
            var usuario = usuarioAplicacao.ListarPorId(id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioAplicacao = new UsuarioAplicacao();
                usuarioAplicacao.Salvar(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Excluir(int id)
        {
            var usuarioAplicacao = new UsuarioAplicacao();
            var usuario = usuarioAplicacao.ListarPorId(id);
            if (usuario == null)
                return HttpNotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var usuarioAplicacao = new UsuarioAplicacao();
            usuarioAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}