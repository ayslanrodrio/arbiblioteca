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
    public class AlunoAplicacao
    {

        private readonly Contexto contexto = new Contexto();

        private void Inserir(Aluno aluno)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO Alunos (Nome, DataNascimento, NomeMae, Endereco, Telefone) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}', '{4}') ",
                aluno.Nome, aluno.DataNascimento, aluno.NomeMae, aluno.Endereco, aluno.Telefone);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Aluno aluno)
        {
            var strQuery = " ";
            strQuery += " UPDATE Alunos SET ";
            strQuery += string.Format(" Nome = '{0}', ", aluno.Nome);
            strQuery += string.Format(" DataNascimento = '{0}', ", aluno.DataNascimento);
            strQuery += string.Format(" NomeMae = '{0}', ", aluno.NomeMae);
            strQuery += string.Format(" Endereco = '{0}', ", aluno.Endereco);
            strQuery += string.Format(" Telefone = '{0}' ", aluno.Telefone);
            strQuery += string.Format(" WHERE CodAluno = {0}", aluno.CodAluno);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Aluno aluno)
        {
            if (aluno.CodAluno > 0)
                Alterar(aluno);
            else
                Inserir(aluno);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM Alunos WHERE codAluno = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Aluno> ListarTodos()
        {
            var strQuery = " SELECT * FROM Alunos ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Aluno ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM Alunos WHERE CodAluno = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Aluno> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                var tempObjeto = new Aluno
                {
                    CodAluno = int.Parse(reader["CodAluno"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    DataNascimento = reader["DataNascimento"].ToString(),
                    NomeMae = reader["NomeMae"].ToString(),
                    Endereco = reader["Endereco"].ToString(),
                    Telefone = reader["Telefone"].ToString()
                };
                alunos.Add(tempObjeto);
            }
            return alunos;
        }

    }
}
