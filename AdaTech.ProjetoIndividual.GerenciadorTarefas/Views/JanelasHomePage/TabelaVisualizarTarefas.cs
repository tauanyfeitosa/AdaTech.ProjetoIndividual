using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.TabelasDetalhesHomePage;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    public partial class TabelaVisualizarTarefas : Form
    {
        private Panel panel;
        private DataGridView dataGridViewTarefas = new DataGridView();

        public TabelaVisualizarTarefas()
        {
            InitializeComponent();
            CarregarTarefas();
            InicializarDataGridView();
        }

        private void CarregarTarefas()
        {
            try
            {
                List<Tarefas> tarefas = TarefaData.Listar();

                if (tarefas.Count > 0)
                {
                    dataGridViewTarefas.DataSource = tarefas;
                }
                else
                {
                    MessageBox.Show("A lista de tarefas está vazia.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar tarefas: {ex.Message}");
            }
        }

        private void InicializarDataGridView()
        {
            panel = new Panel();
            panel.Dock = DockStyle.Fill;

            dataGridViewTarefas.Dock = DockStyle.Fill;
            dataGridViewTarefas.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            dataGridViewTarefas.Columns.Add(colId);

            DataGridViewTextBoxColumn colTitulo = new DataGridViewTextBoxColumn();
            colTitulo.DataPropertyName = "Titulo";
            colTitulo.HeaderText = "Título";
            dataGridViewTarefas.Columns.Add(colTitulo);

            DataGridViewTextBoxColumn colResponsavel = new DataGridViewTextBoxColumn();
            colResponsavel.DataPropertyName = "NomeResponsavel";
            colResponsavel.HeaderText = "Responsável";
            dataGridViewTarefas.Columns.Add(colResponsavel);

            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            dataGridViewTarefas.Columns.Add(colStatus);

            DataGridViewTextBoxColumn colProjeto = new DataGridViewTextBoxColumn();
            colProjeto.DataPropertyName = "NomeProjeto";
            colProjeto.HeaderText = "Projeto";
            dataGridViewTarefas.Columns.Add(colProjeto);

            dataGridViewTarefas.CellClick += DataGridViewTarefas_CellClick;

            dataGridViewTarefas.Width = 800;
            dataGridViewTarefas.Height = 400;

            panel.Controls.Add(dataGridViewTarefas);
            Controls.Add(panel);
        }

        private void DataGridViewTarefas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Tarefas tarefaSelecionada = dataGridViewTarefas.Rows[e.RowIndex].DataBoundItem as Tarefas;

                if (tarefaSelecionada != null)
                {
                    MostrarDetalhesTarefa(tarefaSelecionada);
                }
            }
        }

        private void MostrarDetalhesTarefa(Tarefas tarefa)
        {
            DetalhesTarefas detalhesForm = new DetalhesTarefas(tarefa);
            detalhesForm.ShowDialog();
        }
    }
}
