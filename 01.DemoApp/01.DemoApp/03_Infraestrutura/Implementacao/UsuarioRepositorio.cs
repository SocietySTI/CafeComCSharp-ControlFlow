using _01.DemoApp._02_Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DemoApp._02_Dominio;

namespace _01.DemoApp._03_Infraestrutura.Implementacao
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private IDictionary<string, Usuario> _tabelaUsuario = new Dictionary<string, Usuario>();

        #region Implementação Interface IUsuarioRepositorio
        public void Adicionar(Usuario usuario)
        {
            _tabelaUsuario.Add(usuario.Nome, usuario);
        }

        public Usuario Localizar(string nomeUsuario)
        {
            Usuario usuario = null;
            if (!_tabelaUsuario.TryGetValue(nomeUsuario, out usuario))
                return null;
            return usuario;
        }

        #endregion
    }
}
