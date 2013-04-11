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
    public class EmprestimoController : Controller
    {
        public ActionResult Index()
        {
            var emprestimoAplicacao = new EmprestimoAplicacao();
            return View(emprestimoAplicacao.ListarTodos());
        }

        public ActionResult Detalhes(int id)
        {
            var emprestimoAplicao = new EmprestimoAplicacao();
            var emprestimo = emprestimoAplicao.ListarPorId(id);
            if (emprestimo == null)
                return HttpNotFound();
            return View(emprestimo);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                var produtoAplicacao = new EmprestimoAplicacao();
                produtoAplicacao.Salvar(emprestimo);
                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }

        public ActionResult Editar(int id)
        {
            var emprestimoAplicacao = new EmprestimoAplicacao();
            var produto = emprestimoAplicacao.ListarPorId(id);
            if (produto == null)
                return HttpNotFound();

            return View(produto);
        }

        [HttpPost]
        public ActionResult Editar(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                var emprestimoAplicacao = new EmprestimoAplicacao();
                emprestimoAplicacao.Salvar(emprestimo);
                return RedirectToAction("Index");
            }

            return View(emprestimo);
        }

        public ActionResult Excluir(int id)
        {
            var emprestimoAplicacao = new EmprestimoAplicacao();
            var emprestimo = emprestimoAplicacao.ListarPorId(id);
            if (emprestimo == null)
                return HttpNotFound();

            return View(emprestimo);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var emprestimoAplicacao = new EmprestimoAplicacao();
            emprestimoAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
