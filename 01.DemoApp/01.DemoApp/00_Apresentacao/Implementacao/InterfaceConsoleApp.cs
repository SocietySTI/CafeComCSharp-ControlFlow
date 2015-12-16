using _01.DemoApp._00_Apresentacao.Implementacao.Comandos;
using _01.DemoApp._00_Apresentacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp._00_Apresentacao.Implementacao
{
    public class InterfaceConsoleApp : IInterfaceDoUsuario
    {
        private IComando _comandoAtual = new FazerNadaComando();
        private readonly IEnumerable<MenuItem> _menu;
        private readonly IAplicacaoService _appService;

        public string DisplayParaUsuarioLogado
        {
            get
            {
                if (_appService.UsuarioEstaLogado)
                    return _appService.NomeDoUsuarioLogado;
                return "N/A";
            }
        }

        public InterfaceConsoleApp(IAplicacaoService appService)
        {
            _appService = appService;

            _menu = new MenuItem[]
            {
                MenuItem.CriarMenu("Registrar usuário", 'R', new RegistrarUsuarioComando(appService), () => true),
                MenuItem.CriarMenu("Login", 'L', new LoginComando(appService), () => true),
                MenuItem.CriarMenu("LogOut", 'O', new FazerNadaComando(), () => _appService.UsuarioEstaLogado),
                MenuItem.CriarMenu("Depositar", 'D', new FazerNadaComando(), () => _appService.UsuarioEstaLogado),
                MenuItem.CriarMenu("Comprar", 'C', new FazerNadaComando(), () => _appService.UsuarioEstaLogado),
                MenuItem.CriarMenuParaFinalizar("Sair", 'S')
            };
        }

        #region Implementação da Interface IInterfaceDoUsuario

        public bool LerComando()
        {
            AtualizarTela();
            var menuSelecionado = SelecionarOpcaoMenu();
            if (menuSelecionado.EhComandoParaFinalizar)
                return false;
            _comandoAtual = menuSelecionado.Comando;
            return true;
        }

        public void ExecutarComando()
        {
            _comandoAtual.Executar();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pressione ENTER para continuar....");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        #endregion

        private MenuItem SelecionarOpcaoMenu()
        {
            var tecla = Console.ReadKey(true);
            var menuSelecionado = _menu.Single(m => m.TeclaCorresponde(tecla.KeyChar));
            return menuSelecionado;
        }

        private void AtualizarTela()
        {
            Console.Clear();
            ExibirStatus();
            ExibirMenu();
        }

        private void ExibirStatus()
        {
            Console.Write("Usuário logado: ");
            Destacar(DisplayParaUsuarioLogado);
            Console.WriteLine();

            Console.WriteLine();
        }        

        private void ExibirMenu()
        {
            Console.WriteLine("Selecione a opção desejada:");
            Console.WriteLine();

            foreach (MenuItem item in _menu)
                item.Exibir();

            Console.WriteLine();
        }

        private void Destacar(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(mensagem);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
