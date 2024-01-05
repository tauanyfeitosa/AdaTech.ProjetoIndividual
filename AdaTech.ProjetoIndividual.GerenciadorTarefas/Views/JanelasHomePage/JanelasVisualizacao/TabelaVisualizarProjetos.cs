using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    public partial class TabelaVisualizarProjetos : Form
    {
        private DataGridView dataGridViewProjetos;

        public TabelaVisualizarProjetos()
        {
            InitializeComponent();
            InicializarDataGridView();
            CarregarProjetos();
        }

        private void InicializarDataGridView()
        {
            dataGridViewProjetos = new DataGridView();
            dataGridViewProjetos.Dock = DockStyle.Fill;
            dataGridViewProjetos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colNomeProjeto = new DataGridViewTextBoxColumn();
            colNomeProjeto.DataPropertyName = "NomeProjeto";
            colNomeProjeto.HeaderText = "Nome do Projeto";
            dataGridViewProjetos.Columns.Add(colNomeProjeto);

            DataGridViewTextBoxColumn colDataInicio = new DataGridViewTextBoxColumn();
            colDataInicio.DataPropertyName = "DataInicio";
            colDataInicio.HeaderText = "Data de Início";
            dataGridViewProjetos.Columns.Add(colDataInicio);

            Controls.Add(dataGridViewProjetos);
        }

        private void CarregarProjetos()
        {
            try
            {
                var projetos = ProjetoData.Listar();

                if (projetos.Count > 0)
                {
                    dataGridViewProjetos.DataSource = projetos;
                }
                else
                {
                    MessageBox.Show("A lista de projetos está vazia.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar projetos: {ex.Message}");
            }
        }
    }
}
