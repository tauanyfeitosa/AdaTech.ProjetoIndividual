using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.TabelasDetalhesHomePage
{
    internal partial class DetalhesUsuarios : Form
    {
        private Usuario _usuario;
        private List<Tarefas> _tarefas = new List<Tarefas>();
        private Label lblNome = new Label();
        private Label lblCargo = new Label();
        private Label lblProjetos = new Label();
        private ListBox listBoxTarefas = new ListBox();

        internal DetalhesUsuarios(Usuario usuario, List<Tarefas> tarefas)
        {
            _usuario = usuario;
            _tarefas = tarefas;
            InitializeComponent();
            CarregarDetalhes();
        }

        private void CarregarDetalhes()
        {
            this.Text = $"Detalhes do Usuário: {_usuario.Nome}";
            this.BackColor = Color.LightGray;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblNome.Text = $"Nome: {_usuario.Nome}";
            lblNome.Font = new Font("Arial", 14, FontStyle.Bold);
            lblNome.ForeColor = Color.Blue;
            lblNome.Location = new Point(20, 20);
            lblNome.AutoSize = true;

            lblCargo.Text = $"Cargo: {_usuario.Cargo}";
            lblCargo.Font = new Font("Arial", 12, FontStyle.Regular);
            lblCargo.Location = new Point(20, 60);
            lblCargo.AutoSize = true;

            if (_usuario is Desenvolvedor desenvolvedor)
            {
                lblProjetos.Text = $"Projetos: {desenvolvedor.Projeto.NomeProjeto}";
            }
            else if (_usuario is TechLeader techLeader)
            {
                lblProjetos.Text = $"Projetos: {techLeader.Projeto.NomeProjeto}";
            }
            else
            {
                lblProjetos.Text = "Projetos: Não aplicável para administradores";
            }
            lblProjetos.Font = new Font("Arial", 12, FontStyle.Regular);
            lblProjetos.Location = new Point(20, 90);
            lblProjetos.AutoSize = true;

            listBoxTarefas.Font = new Font("Arial", 12, FontStyle.Regular);
            listBoxTarefas.Location = new Point(20, 120);
            listBoxTarefas.Size = new Size(600, 200);
            listBoxTarefas.MultiColumn = true;
            listBoxTarefas.ColumnWidth = 200;
            listBoxTarefas.ScrollAlwaysVisible = true;

            if (_tarefas.Count > 0)
            {
                foreach (var tarefa in _tarefas)
                {
                    listBoxTarefas.Items.Add($"Tarefa: {tarefa.Titulo} | Status: {tarefa.Status}");
                }
            }
            else
            {
                listBoxTarefas.Items.Add("Nenhuma tarefa atribuída a este usuário.");
            }

            Button buttonFechar = new Button();
            buttonFechar.Text = "Fechar";
            buttonFechar.Font = new Font("Arial", 12, FontStyle.Regular);
            buttonFechar.Location = new Point(20, 350);
            buttonFechar.Click += (sender, e) => this.Close();

            Controls.Add(lblNome);
            Controls.Add(lblCargo);
            Controls.Add(lblProjetos);
            Controls.Add(listBoxTarefas);
            Controls.Add(buttonFechar);
        }
    }
}
