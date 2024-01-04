using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness
{
    internal static class TarefaData
    {
        private static List<Tarefas> _tarefas = new List<Tarefas>();

        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Data";
        private static readonly string _FILE_PATH = Path.Combine(_DIRECTORY_PATH, "Tarefas.txt");

        internal static List<Tarefas> Tarefas { get => _tarefas; set => _tarefas = value; }

        internal static void CarregarDados()
        {
            _tarefas = LerTarefasTxt();
        }

        internal static Tarefas AdicionarTarefa(int id, string titulo, string descricao, DateTime dataInicio, PrioridadeTarefa prioridade, Usuario usuario, DateTime fim, List<int> idTarefas)
        {
            List<Tarefas> tarefasRelacionadas = BuscarPorId(idTarefas);
            var tarefa = new Tarefas(id, titulo, descricao, dataInicio, prioridade, usuario, fim, tarefasRelacionadas);
            _tarefas.Add(tarefa);
            return tarefa;
        }

        internal static Tarefas AdicionarTarefa(string titulo, string descricao, DateTime dataInicio, PrioridadeTarefa prioridade, Usuario usuario, DateTime fim, List<int> idTarefas)
        {
            List<Tarefas> tarefasRelacionadas = BuscarPorId(idTarefas);
            var tarefa = new Tarefas(titulo, descricao, dataInicio, prioridade, usuario, fim, tarefasRelacionadas);
            _tarefas.Add(tarefa);
            return tarefa;
        }

        internal static List<Tarefas> Listar()
        {
            return _tarefas;
        }

        internal static Tarefas BuscarPorId(int id)
        {
            return _tarefas.FirstOrDefault(x => x != null && x.Id == id);
        }


        internal static List<Tarefas> BuscarPorId(List<int> ids)
        {
            List<Tarefas> tarefas = new List<Tarefas>();
            if (ids != null) 
            {
                return _tarefas.Where(x => ids.Contains(x.Id)).ToList();
            }
            return tarefas;
        }

            internal static void Editar(Tarefas tarefa)
        {
            var tarefaEditar = BuscarPorId(tarefa.Id);
            tarefaEditar.Titulo = tarefa.Titulo;
            tarefaEditar.Descricao = tarefa.Descricao;
            tarefaEditar.DataInicio = tarefa.DataInicio;
            tarefaEditar.DataFimPrevista = tarefa.DataFimPrevista;
            tarefaEditar.Responsavel = tarefa.Responsavel;
        }
        internal static bool VerificarId(int id)
        {
            return _tarefas.Any(x => x.Id == id);
        }

        internal static Tarefas ObterPorId(int id)
        {
            return _tarefas.FirstOrDefault(x => x.Id == id);
        }

        internal static List<Tarefas> LerTarefasTxt()
        {
            var tarefas = new List<Tarefas>();

            if (File.Exists(_FILE_PATH))
            {
                using (StreamReader sr = new StreamReader(_FILE_PATH))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        Tarefas tarefa = ConverterLinha(linha);
                        tarefas.Add(tarefa);
                    }
                }
            }
            return tarefas;
        }

        internal static Tarefas ConverterLinha(string linha)
        {
            var dados = linha.Split(',');
            var titulo = dados[0];
            var descricao = dados[1];
            var dataInicio = DateTime.Parse(dados[2]);
            var dataFimPrevista = DateTime.Parse(dados[3]);
            var prioridade = (PrioridadeTarefa)Enum.Parse(typeof(PrioridadeTarefa), dados[4]);
            Usuario usuario = UsuarioData.SelecionarUsuario(dados[5]);
            var id = int.Parse(dados[6]);

            var tarefa = AdicionarTarefa(id, titulo, descricao, dataInicio, prioridade, usuario, dataFimPrevista, null);
            if (dados.Length > 7)
            {
                var status = (StatusTarefa)Enum.Parse(typeof(StatusTarefa), dados[7]);
                tarefa.Status = status;

                if (dados.Length > 8)
                {
                    if (dados[8] != "null" || dados[8] != "")
                    {
                        if (DateTime.TryParse(dados[8], out DateTime dataConclusao))
                        {
                            tarefa.DataConclusao = dataConclusao;
                        }
                            
                    }
                    
                    if (dados.Length > 9)
                    {
                        List<int> idTarefas = dados[6].Split('/').Select(x => int.Parse(x)).ToList();
                        tarefa.TarefasRelacionada = BuscarPorId(idTarefas);

                    }
                }
            }

            return tarefa;
        }

        internal static void SalvarTarefasTxt(List<Tarefas> tarefas)
        {
            try
            {
                List<string> linhas = new List<string>();

                foreach (var tarefa in tarefas)
                {
                    var linha = $"{tarefa.Id};{tarefa.Titulo};{tarefa.Descricao};{tarefa.DataInicio};{tarefa.DataFimPrevista};{tarefa.Status};{tarefa.Prioridade};{tarefa.DataConclusao};{tarefa.DataCancelamento};{tarefa.Responsavel.Cpf};{string.Join(",", tarefa.TarefasRelacionada.Select(x => x.Id))}";
                    linhas.Add(linha);
                }

                File.AppendAllLines(_FILE_PATH, linhas);

                _tarefas = LerTarefasTxt();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar tarefas", ex);
            }
        }

        internal static List<Tarefas> ObterTarefasPorResponsavel(Usuario usuario)
        {
            return _tarefas.Where(x => x.Responsavel == usuario).ToList();
        }
    }
}
