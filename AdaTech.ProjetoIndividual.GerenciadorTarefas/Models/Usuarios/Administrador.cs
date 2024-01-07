using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios
{
    internal class Administrador: Usuario
    {
        internal Administrador(string senha, string nome, string cpf, string email, bool ativo = true) 
            : base(nome, email, senha, cpf, ativo)
        {

        }
    }
}
