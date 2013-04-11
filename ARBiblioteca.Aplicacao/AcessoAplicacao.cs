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
    public class AcessoAplicacao
    {

        private readonly Contexto contexto = new Contexto();

        public Usuario Logar(string login, string senha)
        {
            var strQuery = string.Format(" SELECT * FROM usuario WHERE login='{0}' and senha='{1}' ", login, senha);
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