using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.ProjetosBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios
{
    internal sealed class Desenvolvedor: Usuario
    {
        private Projetos _projeto;

        internal Projetos Projeto { get => _projeto; set => _projeto = value; }

        internal Desenvolvedor( string senha, string nome, string cpf, string email, string projeto, bool ativo = true) 
            : base(nome, email, senha, cpf, ativo)
        {
            _projeto = ProjetoData.BuscarPorNome(projeto);
        }

        internal void ListarTarefas()
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

        internal void ListarDesenvolvedores()
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

        internal void CriarTarefas()
        {

        }
    }
}
