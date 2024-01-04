using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Controllers
{
    internal class HomePageController
    {
        private readonly Usuario _usuarioLogado;

        internal HomePageController(Usuario usuario)
        {
            _usuarioLogado = usuario;
        }

        internal string FiltrarLogin()
        {
            if (_usuarioLogado is Desenvolvedor)
            {
                return "Desenvolvedor";
            }
            else if (_usuarioLogado is TechLeader)
            {
                return "Tech Leader";
            }
            else
            {
                return "Administrador";
            }
        }
    }
}
