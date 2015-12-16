using _01.DemoApp._01_Aplicacao.Interfaces;
using _01.DemoApp._02_Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp._02_Dominio.Implementacao
{
    public class DominioService : IDominioService
    {
        private readonly IUsuarioRepositorio _repositorioUsuario;

        public DominioService(IUsuarioRepositorio repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        #region Implementação interface IDominioService
        public void CriarUsuario(string nomeUsuario)
        {
            var usuario = new Usuario(nomeUsuario);
            _repositorioUsuario.Adicionar(usuario);
        }

        public bool UsuarioEhRegistrado(string nomeUsuario)
        {
            var usuario = _repositorioUsuario.Localizar(nomeUsuario);
            return usuario != null;
        }

        #endregion

    }
}
