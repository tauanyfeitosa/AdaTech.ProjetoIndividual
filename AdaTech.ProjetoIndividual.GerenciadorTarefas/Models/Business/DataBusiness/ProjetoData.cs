using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.ProjetosBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness
{
    internal class ProjetoData
    {
        private static List<Projetos> _projetos = new List<Projetos>
        {
            new Projetos("Salus", "Combate a Sífilis", DateTime.Now),
            new Projetos("SisVet", "Sistema de Gestão de Clínicas Veterinárias", DateTime.Now),
            new Projetos("SIRI", "Sistema de Inteligência de Risco", DateTime.Now),
            new Projetos("SisCovid", "Sistema de Gestão de Casos de Covid-19", DateTime.Now),
            new Projetos("Salus Pré-Natal", "Combate a Sífilis em Gestantes", DateTime.Now),

        };

        internal static bool AdicionarProjeto(string nomeProjeto, string descricaoProjeto, DateTime dataInicio)
        {
            if (BuscarPorNome(nomeProjeto) == null)
            {
                var projeto = new Projetos(nomeProjeto, descricaoProjeto, dataInicio);
                _projetos.Add(projeto);
                return true;
            } else
            {
                return false;
            }
            
        }

        internal static List<Projetos> Listar()
        {
            return _projetos;
        }

        internal static Projetos BuscarPorNome(string nome)
        {
            return _projetos.FirstOrDefault(x => x.NomeProjeto == nome);
        }

    }
}
