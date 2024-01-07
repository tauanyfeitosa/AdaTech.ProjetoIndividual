using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.ProjetosBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios
{
    internal sealed class TechLeader: Usuario
    {
        private Projetos _projeto;

        internal Projetos Projeto { get => _projeto; set => _projeto = value; }

        internal TechLeader(string senha, string nome, string cpf, string email, string projeto, bool ativo = true) 
            : base(nome, email, senha, cpf, ativo)
        {
            _projeto = ProjetoData.BuscarPorNome(projeto);
        }
    }
}
