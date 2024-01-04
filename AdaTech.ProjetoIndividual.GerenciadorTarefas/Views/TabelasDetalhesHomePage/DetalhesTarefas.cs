using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.TabelasDetalhesHomePage
{
    internal partial class DetalhesTarefas : Form
    {
        private Tarefas _tarefa;

        internal DetalhesTarefas(Tarefas tarefa)
        {
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
    }
}
