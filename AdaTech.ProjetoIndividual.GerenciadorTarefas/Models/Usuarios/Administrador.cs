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

        internal void CadastrarDesenvolvedor()
        {

        }

        internal void CadastrarTarefa()
        {

        }

        internal void EditarTarefa()
        {

        }

        internal void ExcluirTarefa()
        {

        }

        internal void EditarDesenvolvedor()
        {

        }

        internal void ExcluirDesenvolvedor()
        {

        }

        internal void CadastrarTechLeader()
        {

        }

        internal void EditarTechLeader()
        {

        }

        internal void ExcluirTechLeader()
        {

        }

        internal void ListarTarefas()
        {

        }

        internal void ListarDesenvolvedores()
        {

        }

        internal void ListarTechLeaders()
        {

        }

        internal void ListarTarefasConcluidas()
        {

        }

        internal void ListarTarefasPendentes()
        {

        }

        internal void ListarTarefasAtrasadas()
        {

        }

        internal void ListarTarefasEmAndamento()
        {

        }

        internal void ListarTarefasCanceladas()
        {

        }
    }
}
