using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp._02_Dominio
{
    public class Usuario
    {
        public string Nome { get; private set; }

        public Usuario(string nome)
        {
            Nome = nome;
        }
    }
}
