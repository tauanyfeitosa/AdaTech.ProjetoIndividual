using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System.Windows.Forms;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.ProjetosBusiness;

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

        internal static void AdicionarTarefa(int id, string titulo, string descricao, DateTime dataInicio, PrioridadeTarefa prioridade, Usuario usuario, DateTime fim, List<int> idTarefas)
        {
            List<int> tarefasRelacionadas = idTarefas;
            var tarefa = new Tarefas(id, titulo, descricao, dataInicio, prioridade, usuario, fim, tarefasRelacionadas);
            _tarefas.Add(tarefa);
            List<Tarefas> lista = new List<Tarefas>();
            lista.Add(tarefa);
            SalvarTarefasTxt(lista);
        }

        internal static bool AdicionarTarefa(string titulo, string descricao, DateTime dataInicio, PrioridadeTarefa prioridade, Usuario usuario, DateTime fim, List<int> idTarefas)
        {
            try 
            {
                List<int> tarefasRelacionadas = idTarefas;
                var tarefa = new Tarefas(titulo, descricao, dataInicio, prioridade, usuario, fim, tarefasRelacionadas);
                _tarefas.Add(tarefa);
                List<Tarefas> lista = new List<Tarefas>();
                lista.Add(tarefa);
                SalvarTarefasTxt(lista);

                return true;
            }catch
            {
                return false;
            }
        }

        internal static List<Tarefas> Listar()
        {
            return _tarefas;
        }

        internal static List<Tarefas> Listar(Projetos projeto)
        {
            return _tarefas.Where(x => x.Projeto == projeto).ToList();
        }

        internal static List<Tarefas> ListarTarefasDev(Desenvolvedor dev)
        {
            return _tarefas.Where(x => x.Responsavel == dev).ToList();
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

            var tarefa = new Tarefas(id, titulo, descricao, dataInicio, prioridade, usuario, dataFimPrevista, null);
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
                        List<int> idTarefas = dados[9].Split('/').Select(x => int.Parse(x)).ToList();
                        tarefa.TarefasRelacionada = idTarefas;
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
                    MessageBox.Show(tarefa.DataConclusao.ToString());
                    string dataConclusao = tarefa.DataConclusao.Date.ToString("yyyy-MM-dd");
                    MessageBox.Show(dataConclusao);
                    if (tarefa.DataConclusao == DateTime.MinValue)
                    {
                        dataConclusao = "";
                        MessageBox.Show($"Dentro do if: {dataConclusao}");
                    }

                    var linha = $"{tarefa.Titulo},{tarefa.Descricao},{tarefa.DataInicio.Date.ToString("yyyy-MM-dd")},{tarefa.DataFimPrevista.Date.ToString("yyyy-MM-dd")}," +
                    $"{tarefa.Prioridade},{tarefa.Responsavel.Cpf},{tarefa.Id},{tarefa.Status},{dataConclusao}," +
                    $"{string.Join("/", tarefa.TarefasRelacionada)}";

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

        internal static void AprovarTarefa(Tarefas tarefa)
        {
            tarefa.Status = StatusTarefa.Concluida;
            tarefa.DataConclusao = DateTime.Now;
            AtualizarStatus(tarefa);
        }

        internal static void CancelarTarefa(Tarefas tarefa)
        {
            tarefa.Status = StatusTarefa.Cancelada;
            AtualizarStatus(tarefa);
        }

        internal static void AlterarStatus(Tarefas tarefa, StatusTarefa status)
        {
            tarefa.Status = status;
            AtualizarStatus(tarefa);
        }

        internal static void AtualizarStatus(Tarefas tarefa)
        {
            try
            {
                string[] linhas = File.ReadAllLines(_FILE_PATH);

                for (int i = 0; i < linhas.Length; i++)
                {
                    string[] partes = linhas[i].Split(',');

                    if (partes.Length >= 7 && partes[6] == tarefa.Id.ToString())
                    {
                        partes[7] = tarefa.Status.ToString();

                        if (tarefa.Status == StatusTarefa.Concluida)
                        {
                            if (partes.Length <= 8)
                            {
                                Array.Resize(ref partes, 9);
                            }

                            partes[8] = tarefa.DataConclusao.Date.ToString("yyyy-MM-dd");
                        }

                        linhas[i] = string.Join(",", partes);
                        break;
                    }
                }

                File.WriteAllLines(_FILE_PATH, linhas);

                MessageBox.Show("Status da tarefa atualizado com sucesso no arquivo.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar o status da tarefa no arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
