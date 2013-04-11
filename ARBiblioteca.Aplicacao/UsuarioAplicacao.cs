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
    public class UsuarioAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Usuario usuario)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO usuario (Nome, Login, Senha) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}') ",
                usuario.Nome, usuario.Login, usuario.Senha);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Usuario usuario)
        {
            var strQuery = " ";
            strQuery += " UPDATE usuario SET ";
            strQuery += string.Format(" Nome = '{0}', ", usuario.Nome);
            strQuery += string.Format(" Login = '{0}', ", usuario.Login);
            strQuery += string.Format(" Senha = '{0}' ", usuario.Senha);

            strQuery += string.Format(" WHERE UsuarioId = {0}", usuario.UsuarioId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.UsuarioId > 0)
                Alterar(usuario);
            else
                Inserir(usuario);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM usuario WHERE UsuarioId = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Usuario> ListarTodos()
        {
            var strQuery = " SELECT * FROM usuario ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Usuario ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM usuario WHERE UsuarioId = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Usuario> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Usuario>();
            while (reader.Read())
            {
                var tempObjeto = new Usuario
                {
                    UsuarioId = int.Parse(reader["UsuarioId"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Login = reader["Login"].ToString(),
                    Senha = reader["Senha"].ToString()
                };
                usuarios.Add(tempObjeto);
            }
            return usuarios;
        }
    }
}
