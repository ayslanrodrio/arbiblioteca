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
   public class LivroAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Livro livro)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO Livros (Titulo, Autor, Ano, Editora) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}') ",
                livro.Titulo, livro.Autor, livro.Ano, livro.Editora);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Livro livro)
        {
            var strQuery = " ";
            strQuery += " UPDATE Livros SET ";
            strQuery += string.Format(" Titulo = '{0}', ", livro.Titulo);
            strQuery += string.Format(" Autor = '{0}', ", livro.Autor);
            strQuery += string.Format(" Ano = '{0}', ", livro.Ano);
            strQuery += string.Format(" Editora = '{0}' ", livro.Editora);
            strQuery += string.Format(" WHERE CodLivro = {0}", livro.CodLivro);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Livro livro)
        {
            if (livro.CodLivro > 0)
                Alterar(livro);
            else
                Inserir(livro);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM Livros WHERE codlivro = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Livro> ListarTodos()
        {
            var strQuery = " SELECT * FROM Livros ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Livro ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM Livros WHERE CodLivro = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Livro> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var livros = new List<Livro>();
            while (reader.Read())
            {
                var tempObjeto = new Livro
                {
                    CodLivro = int.Parse(reader["CodLivro"].ToString()),
                    Titulo = reader["Titulo"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    Ano = reader["Ano"].ToString(),
                    Editora = reader["Editora"].ToString()
                };
                livros.Add(tempObjeto);
            }
            return livros;
        }

    }
}
