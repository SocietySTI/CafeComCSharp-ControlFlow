using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp._01_Aplicacao.Interfaces
{
    public interface IDominioService
    {
        void CriarUsuario(string nomeUsuario);
        bool UsuarioEhRegistrado(string nomeUsuario);
    }
}
