using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARBiblioteca.Aplicacao;
using ARBiblioteca.Dominio;

namespace ARBiblioteca.UI.Web.Controllers
{
    
    [Authorize]
    public class LivroController : Controller
    {
        public ActionResult Index()
        {
            var livroAplicacao = new LivroAplicacao();
            return View(livroAplicacao.ListarTodos());
        }

        public ActionResult Detalhes(int id)
        {
            var livroAplicacao = new LivroAplicacao();
            var livro = livroAplicacao.ListarPorId(id);
            if (livro == null)
                return HttpNotFound();
            return View(livro);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Livro livro)
        {
            if (ModelState.IsValid)
            {
                var livroAplicacao = new LivroAplicacao();
                livroAplicacao.Salvar(livro);
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        public ActionResult Editar(int id)
        {
            var livroAplicacao = new LivroAplicacao();
            var livro = livroAplicacao.ListarPorId(id);
            if (livro == null)
                return HttpNotFound();

            return View(livro);
        }

        [HttpPost]
        public ActionResult Editar(Livro livro)
        {
            if (ModelState.IsValid)
            {
                var livroAplicacao = new LivroAplicacao();
                livroAplicacao.Salvar(livro);
                return RedirectToAction("Index");
            }

            return View(livro);
        }

        public ActionResult Excluir(int id)
        {
            var livroAplicacao = new LivroAplicacao();
            var livro = livroAplicacao.ListarPorId(id);
            if (livro == null)
                return HttpNotFound();

            return View(livro);
        }

        [HttpPost,ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var livroAplicacao = new LivroAplicacao();
            livroAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
