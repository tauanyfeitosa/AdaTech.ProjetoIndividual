using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System;
using System.Collections.Generic;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.ProjetosBusiness;

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
        private DateTime _dataConclusao;
        private DateTime _dataCancelamento;
        private Usuario _usuario;
        private Projetos _projeto;
        private List<int> _tarefasRelacionada;

        public int Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public DateTime DataInicio { get => _dataInicio; set => _dataInicio = value; }
        public DateTime DataFimPrevista { get => _dataFimPrevista; set => _dataFimPrevista = value; }
        public StatusTarefa Status { get => _status; set => _status = value; }
        public PrioridadeTarefa Prioridade { get => _prioridade; set => _prioridade = value; }
        public DateTime DataConclusao { get => _dataConclusao; set => _dataConclusao = value; }
        public DateTime DataCancelamento { get => _dataCancelamento; set => _dataCancelamento = value; }
        public Usuario Responsavel { get => _usuario; set => _usuario = value; }
        public List<int> TarefasRelacionada { get => _tarefasRelacionada; set => _tarefasRelacionada = value; }

        public Projetos Projeto { get => _projeto; }

        public string NomeProjeto { get => _projeto.NomeProjeto; }
        public string NomeResponsavel { get => _usuario.Nome; }

        public string NomeEstilo
        {
            get
            {
                return $"{Id} - {Titulo}";
            }
        }

        public string Cargo
        {
            get
            {
                return _usuario.Cargo;
            }
        }


        internal Tarefas(string titulo, string descricao, DateTime dataInicio, PrioridadeTarefa prioridade, Usuario usuario, DateTime fim, List<int> tarefasRelacionada = null, StatusTarefa status = StatusTarefa.Pendente)
        {
            _titulo = titulo;
            _descricao = descricao;
            _dataInicio = dataInicio;
            _dataFimPrevista = fim;
            _status = status;
            _prioridade = prioridade;
            _usuario = usuario;
            _tarefasRelacionada = tarefasRelacionada;
            _id = GerarId();
            _projeto = (usuario is TechLeader techLeader) ? techLeader.Projeto :
                       (usuario is Desenvolvedor desenvolvedor) ? desenvolvedor.Projeto :
                        null;
        }

        internal Tarefas(int id,string titulo, string descricao, DateTime dataInicio, PrioridadeTarefa prioridade, Usuario usuario, DateTime fim, List<int> tarefasRelacionada = null, StatusTarefa status = StatusTarefa.Pendente)
        {
            _titulo = titulo;
            _descricao = descricao;
            _dataInicio = dataInicio;
            _dataFimPrevista = fim;
            _status = status;
            _prioridade = prioridade;
            _usuario = usuario;
            _tarefasRelacionada = tarefasRelacionada;
            _id = id;
            _projeto = (usuario is TechLeader techLeader) ? techLeader.Projeto :
                       (usuario is Desenvolvedor desenvolvedor) ? desenvolvedor.Projeto :
                        null;
        }

        internal int GerarId()
        {
            int id;
            do
            {
                id = new Random().Next(1, 1000);
            } while (TarefaData.VerificarId(_id));

            return id;
        }

    }
}
