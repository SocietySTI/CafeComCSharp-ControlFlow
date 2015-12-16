using _01.DemoApp._00_Apresentacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp._00_Apresentacao.Implementacao.Comandos
{
    public class RegistrarUsuarioComando : IComando
    {
        private readonly IAplicacaoService _appService;

        public RegistrarUsuarioComando(IAplicacaoService appService)
        {
            _appService = appService;
        }

        #region Implementação interface IComando
        public void Executar()
        {
            Console.Write("Informe o nome do usuário: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            var nomeUsuario = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            _appService.RegistrarUsuario(nomeUsuario);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuário '{0}' foi registrado com sucesso!", nomeUsuario);
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion
    }
}
