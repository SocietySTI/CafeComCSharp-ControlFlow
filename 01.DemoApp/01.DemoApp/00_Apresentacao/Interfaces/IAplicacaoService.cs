using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp._00_Apresentacao.Interfaces
{
    public interface IAplicacaoService
    {
        bool UsuarioEstaLogado { get; }
        string NomeDoUsuarioLogado { get; }

        void RegistrarUsuario(string nomeUsuario);
        bool Login(string nomeUsuario);
    }
}
