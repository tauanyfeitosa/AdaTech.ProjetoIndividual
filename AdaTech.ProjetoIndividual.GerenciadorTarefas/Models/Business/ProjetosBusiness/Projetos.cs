using System;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.ProjetosBusiness
{
    internal class Projetos
    {
        private string _nomeProjeto;
        private string _descricaoProjeto;
        private DateTime _dataInicio;
        private DateTime _dataTermino;
        private StatusProjeto _statusProjeto;
        private string _codigoProjeto;

        public string NomeProjeto { get => _nomeProjeto; set => _nomeProjeto = value; }
        internal string DescricaoProjeto { get => _descricaoProjeto; set => _descricaoProjeto = value; }
        public DateTime DataInicio { get => _dataInicio.Date; set => _dataInicio = value; }
        internal DateTime DataTermino { get => _dataTermino; set => _dataTermino = value; }
        internal StatusProjeto StatusProjeto { get => _statusProjeto; set => _statusProjeto = value; }

        internal Projetos(string nomeProjeto, string descricaoProjeto, DateTime dataInicio)
        {
            _nomeProjeto = nomeProjeto;
            _descricaoProjeto = descricaoProjeto;
            _dataInicio = dataInicio;
            _statusProjeto = StatusProjeto.EmAndamento;
            _codigoProjeto = GerarCodigoProjeto();
        }

        internal string GerarCodigoProjeto()
        {
            long timestamp = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            string codigoProjeto = $"PROJ_{timestamp}";

            return codigoProjeto;
        }
    }
}
