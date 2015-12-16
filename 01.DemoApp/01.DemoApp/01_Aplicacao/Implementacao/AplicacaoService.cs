using _01.DemoApp._00_Apresentacao.Interfaces;
using _01.DemoApp._01_Aplicacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp._01_Aplicacao.Implementacao
{
    public class AplicacaoService : IAplicacaoService
    {
        private readonly IDominioService _dominioService;
        private string _usuarioLogado;

        public AplicacaoService(IDominioService dominioService)
        {
            _dominioService = dominioService;
            _usuarioLogado = String.Empty;
        }

        #region Implementação interface IAplicacaoService
        public bool UsuarioEstaLogado { get { return !String.IsNullOrEmpty(_usuarioLogado); } }

        public string NomeDoUsuarioLogado
        {
            get
            {
                GarantirQueUsuarioEstaLogado();
                return _usuarioLogado;
            }            
        }       

        public void RegistrarUsuario(string nomeUsuario)
        {
            _dominioService.CriarUsuario(nomeUsuario);
        }

        public bool Login(string nomeUsuario)
        {
            var logado = _dominioService.UsuarioEhRegistrado(nomeUsuario);

            if (logado)
                _usuarioLogado = nomeUsuario;

            return logado;
        }

        #endregion

        private void GarantirQueUsuarioEstaLogado()
        {
            if (!UsuarioEstaLogado)
                throw new InvalidOperationException("Nenhum usuário logado");
        }
    }
}
