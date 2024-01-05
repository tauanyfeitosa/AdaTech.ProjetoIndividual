using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.TabelasDetalhesHomePage
{
    internal partial class DetalhesTarefas : Form
    {
        private Tarefas _tarefa;
        private Usuario _usuario;

        internal DetalhesTarefas(Tarefas tarefa, Usuario usuario)
        {
            this._usuario = usuario;
            _tarefa = tarefa;
            InitializeComponent();

            DetalharTarefas();
        }

        private void DetalharTarefas()
        {
            this.Text = "Detalhes da Tarefa";
            this.BackColor = Color.LightGray;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label labelDetalhes = new Label();
            labelDetalhes.Text = $"Detalhes da Tarefa: {_tarefa.Titulo}";
            labelDetalhes.Font = new Font("Arial", 14, FontStyle.Bold);
            labelDetalhes.ForeColor = Color.Blue;
            labelDetalhes.Location = new Point(20, 20);
            labelDetalhes.AutoSize = true;
            Controls.Add(labelDetalhes);

            Label labelId = CriarLabel("ID: " + _tarefa.Id, 20, 60);
            Label labelResponsavel = CriarLabel("Responsável: " + _tarefa.Responsavel.Nome, 20, 90);
            Label labelStatus = CriarLabel("Status: " + _tarefa.Status, 20, 120);
            Label labelProjeto = CriarLabel("Projeto: " + _tarefa.Projeto.NomeProjeto, 20, 150);

            Button buttonFechar = new Button();
            buttonFechar.Text = "Fechar";
            buttonFechar.Font = new Font("Arial", 12, FontStyle.Regular);
            buttonFechar.Location = new Point(20, 190);
            buttonFechar.Click += (sender, e) => this.Close();
            Controls.Add(buttonFechar);

            if (_usuario is TechLeader && _tarefa.Status != StatusTarefa.Concluida)
            {
                Button btnConcluir = new Button();
                btnConcluir.Text = "Concluir";
                btnConcluir.AutoSize = true;
                btnConcluir.Font = new Font("Arial", 12, FontStyle.Regular);
                btnConcluir.Location = new Point(100, 190);
                btnConcluir.Click += (sender, e) => TarefaData.AprovarTarefa(_tarefa);
                Controls.Add(btnConcluir);
            }

            if (_usuario is TechLeader && _tarefa.Status != StatusTarefa.Cancelada)
            {
                Button btnCancelar = new Button();
                btnCancelar.Text = "Cancelar";
                btnCancelar.AutoSize = true;
                btnCancelar.Font = new Font("Arial", 12, FontStyle.Regular);
                btnCancelar.Location = new Point(20, 230);
                btnCancelar.Click += (sender, e) => TarefaData.CancelarTarefa(_tarefa);
                Controls.Add(btnCancelar);
            }

            if (_usuario is Desenvolvedor && _tarefa.Responsavel == _usuario && _tarefa.Status != StatusTarefa.Concluida)
            {
                ComboBox cmbStatus = new ComboBox();
                cmbStatus.Items.AddRange(Enum.GetNames(typeof(StatusTarefa)));
                cmbStatus.Font = new Font("Arial", 12, FontStyle.Regular);
                cmbStatus.Location = new Point(100, 190);
                cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList; 
                Controls.Add(cmbStatus);

                cmbStatus.SelectedIndexChanged += (sender, e) => AtualizarStatusTarefa(cmbStatus);
            }
        }

        private Label CriarLabel(string texto, int x, int y)
        {
            Label label = new Label();
            label.Text = texto;
            label.Font = new Font("Arial", 12, FontStyle.Regular);
            label.Location = new Point(x, y);
            label.AutoSize = true;
            Controls.Add(label);
            return label;
        }

        private void AtualizarStatusTarefa(ComboBox cmbStatus)
        {
            if (_usuario is Desenvolvedor && _tarefa.Responsavel == _usuario && _tarefa.Status != StatusTarefa.Concluida)
            {
                if (Enum.TryParse(cmbStatus.SelectedItem.ToString(), out StatusTarefa novoStatus))
                {
                    TarefaData.AlterarStatus(_tarefa, novoStatus);
                    MessageBox.Show($"Status da tarefa atualizado para: {novoStatus}");
                }
                else
                {
                    MessageBox.Show("Escolha um status válido para a tarefa.");
                }
            }
        }
    }
}
