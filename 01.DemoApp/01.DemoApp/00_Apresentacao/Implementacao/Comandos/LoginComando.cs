using _01.DemoApp._00_Apresentacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp._00_Apresentacao.Implementacao.Comandos
{
    public class LoginComando: IComando
    {
        private readonly IAplicacaoService _appService;

        public LoginComando(IAplicacaoService appService)
        {
            _appService = appService;
        }

        #region Implementação interface IComando

        public void Executar()
        {
            Console.Write("Nome do usuário: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            var nomeUsuario = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if(_appService.Login(nomeUsuario))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Usuário '{0}' foi logado corretamente.", nomeUsuario);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falha ao realizar login do usuário '{0}'", nomeUsuario);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion  
    }
}
