using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DemoApp._02_Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        void Adicionar(Usuario usuario);
        Usuario Localizar(string nomeUsuario);
    }
}
