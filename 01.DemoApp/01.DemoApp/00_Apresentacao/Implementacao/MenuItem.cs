using _01.DemoApp._00_Apresentacao.Implementacao.Comandos;
using _01.DemoApp._00_Apresentacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp._00_Apresentacao.Implementacao
{
    public class MenuItem
    {
        private readonly string _descricao;
        private readonly char _teclaAtalho;
        private readonly bool _deveFinalizarPrograma;
        private readonly IComando _comando;
        private readonly Func<bool> _ehVisivel;

        private  MenuItem(string descricao, char teclaAtalho, bool deveFinalizarPrograma, IComando comando, Func<bool> ehVisivel)
        {
            _descricao = descricao;
            _teclaAtalho = teclaAtalho;
            _deveFinalizarPrograma = deveFinalizarPrograma;
            _comando = comando;
            _ehVisivel = ehVisivel;
        }

        public bool EhComandoParaFinalizar { get { return _deveFinalizarPrograma; } }
        public IComando Comando {  get { return _comando; } }


        #region Fabrica
        public static MenuItem CriarMenuParaFinalizar(string descricao, char teclaAtalho)
        {
            return new MenuItem(descricao, teclaAtalho, true, new FazerNadaComando(), () => true);
        }

        public static MenuItem CriarMenu(string descricao, char teclaAtalho, IComando comando, Func<bool> ehVisivel)
        {
            return new MenuItem(descricao, teclaAtalho, false, comando, ehVisivel);
        }
        #endregion

        public void Exibir()
        {
            if (!_ehVisivel())
                return;

            Console.Write("(");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(_teclaAtalho);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(")");

            Console.Write(" {0}", _descricao);
            Console.WriteLine();
        }

        public bool TeclaCorresponde(char tecla)
        {
            return _ehVisivel() && char.ToLower(_teclaAtalho) == char.ToLower(tecla);
        }


    }
}
