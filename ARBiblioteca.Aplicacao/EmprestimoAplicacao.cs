using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARBiblioteca.Dominio;
using ARBiblioteca.Repositorio;

namespace ARBiblioteca.Aplicacao
{
    public class EmprestimoAplicacao
    {

        private readonly Contexto contexto = new Contexto();

        private void Inserir(Emprestimo emprestimo)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO Emprestimo (CodAluno, CodLivro, DataEmprestimo, DataDevolucao) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}') ",
                emprestimo.CodAluno, emprestimo.CodLivro, emprestimo.DataEmprestimo, emprestimo.DataDevolucao);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Emprestimo emprestimo)
        {
            var strQuery = " ";
            strQuery += " UPDATE Emprestimo SET ";
            strQuery += string.Format(" CodAluno = '{0}', ", emprestimo.CodAluno);
            strQuery += string.Format(" CodLivro = '{0}', ", emprestimo.CodLivro);
            strQuery += string.Format(" DataEmprestimo = '{0}', ", emprestimo.DataEmprestimo);
            strQuery += string.Format(" DataDevolucao = '{0}', ", emprestimo.DataDevolucao);
            strQuery += string.Format(" WHERE CodEmprestimo = {0}", emprestimo.CodEmprestimo);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Emprestimo emprestimo)
        {
            if (emprestimo.CodEmprestimo > 0)
                Alterar(emprestimo);
            else
                Inserir(emprestimo);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM Emprestimo WHERE CodEmprestimo = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Emprestimo> ListarTodos()
        {
            var strQuery = " SELECT * FROM Emprestimo ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Emprestimo ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM Emprestimo WHERE CodEmprestimo = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Emprestimo> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var emprestimos = new List<Emprestimo>();
            while (reader.Read())
            {
                var tempObjeto = new Emprestimo
                {
                    CodEmprestimo = int.Parse(reader["CodEmprestimo"].ToString()),
                    CodAluno = int.Parse(reader["CodAluno"].ToString()),
                    CodLivro = int.Parse(reader["CodLivro"].ToString()),
                    DataEmprestimo = reader["DataEmprestimo"].ToString(),
                    DataDevolucao = reader["DataDevolucao"].ToString(),
                };
                emprestimos.Add(tempObjeto);
            }
            return emprestimos;
        }

    }
}