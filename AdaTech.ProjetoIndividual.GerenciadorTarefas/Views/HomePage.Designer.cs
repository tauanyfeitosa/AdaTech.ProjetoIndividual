using AdaTech.ProjetoIndividual.GerenciadorTarefas.Controllers;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views
{
    partial class HomePage
    {
        private bool _confirmacaoSaidaExibida = false;
        private Label _lblBemVindo;
        private Usuario _usuarioLogado;
        private HomePageController _homePageController;
        private Panel _painelHomePage;
        private Button _btnLogout;
        private Button btnVisualizarTarefas;
        private Button btnCriarTarefa;
        private Button btnVisualizarUsuarios;
        private Button btnAlterarSenha;
        private Button btnCadastrarDev;
        private Button btnAdicionarProjeto;
        private Button btnVisualizarProjeto;
        private Button btnCadastrarTechLeader;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            WindowState = FormWindowState.Maximized;
            int largura = this.ClientSize.Width;
            int altura = this.ClientSize.Height;
            this.Text = "HomePage";

            _painelHomePage = new Panel();
            _painelHomePage.Size = new Size(largura - 200, altura - 200);
            _painelHomePage.Location = new Point((largura - _painelHomePage.Width) / 2, (altura - _painelHomePage.Height) / 2);
            _painelHomePage.BackColor = Color.LightGray;
            _painelHomePage.BorderStyle = BorderStyle.FixedSingle;
            _painelHomePage.Anchor = AnchorStyles.None;
            _painelHomePage.AutoScroll = true;

            _lblBemVindo = new Label();
            _lblBemVindo.Text = $"Bem-vindo, {_usuarioLogado.Nome}\nCargo: {_homePageController.FiltrarLogin()} ";
            _lblBemVindo.BackColor = Color.Transparent;
            _lblBemVindo.ForeColor = Color.Black;
            _lblBemVindo.AutoSize = true;
            _lblBemVindo.Font = new Font("Arial", 20, FontStyle.Bold);
            _lblBemVindo.Location = new System.Drawing.Point((largura - _painelHomePage.Width) / 2, 20);

            _btnLogout = new Button();
            _btnLogout.Size = new Size(100, 30);
            _btnLogout.Location = new Point(_painelHomePage.Width + 100, _painelHomePage.Height + 100);
            _btnLogout.Text = "Logout";
            _btnLogout.Click += OnClickLogout;

            btnVisualizarTarefas = new Button();
            btnVisualizarTarefas.Location = new Point(10, 50);
            btnVisualizarTarefas.Anchor = AnchorStyles.Right;
            btnVisualizarTarefas.Text = "Visualizar Tarefas";
            btnVisualizarTarefas.Click += OnClickVisualizarTarefas;

            btnCriarTarefa = new Button();
            btnCriarTarefa.Location = new Point(10, 90);
            btnCriarTarefa.Anchor = AnchorStyles.Right;
            btnCriarTarefa.Text = "Criar Tarefa";
            btnCriarTarefa.Click += OnClickCriarTarefa;

            btnVisualizarUsuarios = new Button();
            btnVisualizarUsuarios.Location = new Point(10, 130);
            btnVisualizarUsuarios.Anchor = AnchorStyles.Right;
            btnVisualizarUsuarios.Text = "Visualizar Equipe";
            btnVisualizarUsuarios.Click += OnClickVisualizarUsuarios;

            btnAlterarSenha = new Button();
            btnAlterarSenha.Location = new Point(10, 10);
            btnAlterarSenha.Anchor = AnchorStyles.Right;
            btnAlterarSenha.Text = "Primeiro acesso? Alterar Senha";
            btnAlterarSenha.Click += OnClickAlterarSenha;

            btnCadastrarDev = new Button();
            btnCadastrarDev.Location = new Point(10, 130);
            btnCadastrarDev.Anchor = AnchorStyles.Right;
            btnCadastrarDev.Text = "Cadastrar Desenvolvedor";
            btnCadastrarDev.Click += OnClickCadastrarDev;

            btnAdicionarProjeto = new Button();
            btnAdicionarProjeto.Location = new Point(10, 90);
            btnAdicionarProjeto.Anchor = AnchorStyles.Right;
            btnAdicionarProjeto.Text = "Adicionar Projeto";
            btnAdicionarProjeto.Click += OnClickAdicionarProjetos;

            btnVisualizarProjeto = new Button();
            btnVisualizarProjeto.Location = new Point(10, 130);
            btnVisualizarProjeto.Anchor = AnchorStyles.Right;
            btnVisualizarProjeto.Text = "Visualizar Projetos";
            btnVisualizarProjeto.Click += OnClickVisualizarProjetos;

            btnCadastrarTechLeader = new Button();
            btnCadastrarTechLeader.Location = new Point(10, 170);
            btnCadastrarTechLeader.Anchor = AnchorStyles.Right;
            btnCadastrarTechLeader.Text = "Cadastrar Tech Leader";
            btnCadastrarTechLeader.Click += OnClickCadastrarTechLeader;

            Controls.Add(_lblBemVindo);
            Controls.Add(_btnLogout);
        }

        #endregion
    }
}