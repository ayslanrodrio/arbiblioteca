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
    public class AlunoController : Controller
    {
        public ActionResult Index()
        {
            var alunoAplicacao = new AlunoAplicacao();
            return View(alunoAplicacao.ListarTodos());
        }

        public ActionResult Detalhes(int id)
        {
            var alunoAplicacao = new AlunoAplicacao();
            var aluno = alunoAplicacao.ListarPorId(id);
            if (aluno == null)
                return HttpNotFound();
            return View(aluno);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var alunoAplicacao = new AlunoAplicacao();
                alunoAplicacao.Salvar(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public ActionResult Editar(int id)
        {
            var alunoAplicacao = new AlunoAplicacao();
            var aluno = alunoAplicacao.ListarPorId(id);
            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                var alunoAplicacao = new AlunoAplicacao();
                alunoAplicacao.Salvar(aluno);
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        public ActionResult Excluir(int id)
        {
            var alunoAplicacao = new AlunoAplicacao();
            var aluno = alunoAplicacao.ListarPorId(id);
            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var alunoAplicacao = new AlunoAplicacao();
            alunoAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
