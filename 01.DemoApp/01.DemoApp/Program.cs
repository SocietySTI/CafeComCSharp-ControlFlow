using _01.DemoApp._00_Apresentacao.Implementacao;
using _01.DemoApp._01_Aplicacao.Implementacao;
using _01.DemoApp._02_Dominio.Implementacao;
using _01.DemoApp._03_Infraestrutura.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuarioRepositorio = new UsuarioRepositorio();
            var dominioService = new DominioService(usuarioRepositorio);
            var interfaceDoUsuario = new InterfaceConsoleApp(new AplicacaoService(dominioService));

            while (interfaceDoUsuario.LerComando())
                interfaceDoUsuario.ExecutarComando();
        }
    }
}
