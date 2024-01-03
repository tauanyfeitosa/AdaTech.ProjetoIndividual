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

        internal int Id { get => _id; set => _id = value; }
        internal string Titulo { get => _titulo; set => _titulo = value; }
        internal string Descricao { get => _descricao; set => _descricao = value; }
        internal DateTime DataInicio { get => _dataInicio; set => _dataInicio = value; }
        internal DateTime DataFimPrevista { get => _dataFimPrevista; set => _dataFimPrevista = value; }
        internal StatusTarefa Status { get => _status; set => _status = value; }
        internal PrioridadeTarefa Prioridade { get => _prioridade; set => _prioridade = value; }
        internal string Observacoes { get => _observacoes; set => _observacoes = value; }
        internal DateTime DataConclusao { get => _dataConclusao; set => _dataConclusao = value; }
        internal DateTime DataCancelamento { get => _dataCancelamento; set => _dataCancelamento = value; }
        internal Usuario Usuario { get => _usuario; set => _usuario = value; }
        internal List<Tarefas> TarefasRelacionada { get => _tarefasRelacionada; set => _tarefasRelacionada = value; }


        internal Tarefas(string titulo, string descricao, DateTime dataInicio, PrioridadeTarefa prioridade, string observacoes, Usuario usuario, DateTime fim, List<Tarefas> tarefasRelacionada = null, StatusTarefa status = StatusTarefa.Pendente)
        {
            _titulo = titulo;
            _descricao = descricao;
            _dataInicio = dataInicio;
            _dataFimPrevista = fim;
            _status = status;
            _prioridade = prioridade;
            _observacoes = observacoes;
            _usuario = usuario;
            _tarefasRelacionada = tarefasRelacionada;
        }

        internal void EditarTarefa(string titulo = null, string descricao = null, DateTime? dataInicio = null, PrioridadeTarefa? prioridade = null, string observacoes = null, Usuario usuario = null, DateTime? fim = null, List<Tarefas> tarefasRelacionada = null, StatusTarefa? status = null)
        {
            if (titulo != null)
            {
                _titulo = titulo;
            }

            if (descricao != null)
            {
                _descricao = descricao;
            }

            if (dataInicio.HasValue)
            {
                _dataInicio = dataInicio.Value;
            }

            if (fim.HasValue)
            {
                _dataFimPrevista = fim.Value;
            }

            if (status.HasValue)
            {
                _status = status.Value;
            }

            if (prioridade.HasValue)
            {
                _prioridade = prioridade.Value;
            }

            if (observacoes != null)
            {
                _observacoes = observacoes;
            }

            if (usuario != null)
            {
                _usuario = usuario;
            }

            if (tarefasRelacionada != null)
            {
                _tarefasRelacionada = tarefasRelacionada;
            }
        }

        internal void ConcluirTarefa()
        {
            _status = StatusTarefa.Concluida;
            _dataConclusao = DateTime.Now;
        }

        internal void CancelarTarefa()
        {
            _status = StatusTarefa.Cancelada;
            _dataCancelamento = DateTime.Now;
        }

        internal void AdicionarTarefaRelacionada(Tarefas tarefa)
        {
            _tarefasRelacionada.Add(tarefa);
        }

        internal void AdicionarTarefaRelacionada(List<Tarefas> tarefas)
        {
            _tarefasRelacionada.AddRange(tarefas);
        }

        internal void RemoverTarefaRelacionada(Tarefas tarefa)
        {
            _tarefasRelacionada.Remove(tarefa);
        }

        internal void RemoverTarefaRelacionada(List<Tarefas> tarefas)
        {
            foreach (var tarefa in tarefas)
            {
                _tarefasRelacionada.Remove(tarefa);
            }
        }

    }
}
