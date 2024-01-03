using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness
{
    internal static class TarefaData
    {
        private static List<Tarefas> _tarefas = new List<Tarefas>();

        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Data";
        private static readonly string _FILE_PATH = Path.Combine(_DIRECTORY_PATH, "Tarefas.txt");

        static TarefaData()
        {
            _tarefas = LerTarefasTxt();
        }

        internal static Tarefas AdicionarTarefa(string titulo, string descricao, DateTime dataInicio, PrioridadeTarefa prioridade, string observacoes, Usuario usuario, DateTime fim, List<int> idTarefas)
        {
            var tarefasRelacionadas = BuscarPorId(idTarefas);
            var tarefa = new Tarefas(titulo, descricao, dataInicio, prioridade, observacoes, usuario, fim, tarefasRelacionadas);
            _tarefas.Add(tarefa);
            return tarefa;
        }

        internal static List<Tarefas> Listar()
        {
            return _tarefas;
        }

        internal static Tarefas BuscarPorId(int id)
        {
            return _tarefas.FirstOrDefault(x => x.Id == id);
        }

        internal static List<Tarefas> BuscarPorId(List<int> ids)
        {
            return _tarefas.Where(x => ids.Contains(x.Id)).ToList();
        }

        internal static void Editar(Tarefas tarefa)
        {
            var tarefaEditar = BuscarPorId(tarefa.Id);
            tarefaEditar.Titulo = tarefa.Titulo;
            tarefaEditar.Descricao = tarefa.Descricao;
            tarefaEditar.DataInicio = tarefa.DataInicio;
            tarefaEditar.DataFimPrevista = tarefa.DataFimPrevista;
            tarefaEditar.Usuario = tarefa.Usuario;
        }
        internal static bool VerificarId(int id)
        {
            return _tarefas.Any(x => x.Id == id);
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
                    }
                }
            }
            return tarefas;
        }

        internal static Tarefas ConverterLinha(string linha)
        {
            var dados = linha.Split(';');
            var id = int.Parse(dados[0]);
            var titulo = dados[1];
            var descricao = dados[2];
            var dataInicio = DateTime.Parse(dados[3]);
            var dataFimPrevista = DateTime.Parse(dados[4]);
            var status = (StatusTarefa)Enum.Parse(typeof(StatusTarefa), dados[5]);
            var prioridade = (PrioridadeTarefa)Enum.Parse(typeof(PrioridadeTarefa), dados[6]);
            var observacoes = dados[7];
            var dataConclusao = DateTime.Parse(dados[8]);
            var dataCancelamento = DateTime.Parse(dados[9]);
            Usuario usuario = UsuarioData.SelecionarUsuario(dados[10]);
            List<int> idTarefas = dados[11].Split(',').Select(x => int.Parse(x)).ToList();

            return AdicionarTarefa(titulo, descricao, dataInicio, prioridade, observacoes, usuario, dataFimPrevista, idTarefas);
        }

        internal static void SalvarTarefasTxt(List<Tarefas> tarefas)
        {
            try
            {
                List<string> linhas = new List<string>();

                foreach (var tarefa in tarefas)
                {
                    var linha = $"{tarefa.Id};{tarefa.Titulo};{tarefa.Descricao};{tarefa.DataInicio};{tarefa.DataFimPrevista};{tarefa.Status};{tarefa.Prioridade};{tarefa.Observacoes};{tarefa.DataConclusao};{tarefa.DataCancelamento};{tarefa.Usuario.Cpf};{string.Join(",", tarefa.TarefasRelacionada.Select(x => x.Id))}";
                    linhas.Add(linha);
                }

                File.AppendAllLines(_FILE_PATH, linhas);

                _tarefas = LerTarefasTxt();

            } catch (Exception ex)
            {
                throw new Exception("Erro ao salvar tarefas", ex);
            }
        }
    }
}
