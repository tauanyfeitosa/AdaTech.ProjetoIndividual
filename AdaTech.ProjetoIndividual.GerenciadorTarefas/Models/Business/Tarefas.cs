using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business
{
    internal class Tarefas
    {
        private int _id;
        private string _titulo;
        private string _descricao;
        private DateTime _dataInicio;
        private DateTime _dataFimPrevista;
        private StatusTarefa _status;
        private PrioridadeTarefa _prioridade;
        private string _observacoes;
        private DateTime _dataConclusao;
        private DateTime _dataCancelamento;
        private Usuario _usuario;
        private List<Tarefas> _tarefasRelacionada;

        internal Tarefas(string titulo, string descricao, string dataInicio, PrioridadeTarefa prioridade, string observacoes, Usuario usuario, DateTime fim, List<Tarefas> tarefasRelacionada = null, StatusTarefa status = StatusTarefa.Pendente)
        {
            _titulo = titulo;
            _descricao = descricao;
            _dataInicio = dataInicio;
            _dataFimPrevista = fim;
            _status = status;
            _prioridade = prioridade;
            _observacoes = observacoes;
            _dataConclusao = dataConclusao;
            _dataCancelamento = dataCancelamento;
            _usuario = usuario;
            _tarefasRelacionada = tarefasRelacionada;
        }
    }
}
