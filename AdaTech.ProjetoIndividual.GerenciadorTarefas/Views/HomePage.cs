using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Controllers;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views
{
    internal partial class HomePage : Form
    {
        private bool _confirmacaoSaidaExibida = false;
        private Label _lblBemVindo;
        private Usuario _usuarioLogado;
        private HomePageController _homePageController;
        private Panel _painelHomePage;
        private Button _btnLogout;


        internal HomePage(Usuario usuario)
        {
            Load += OnLoad;
            FormClosing += OnFormClosing;
            this._usuarioLogado = usuario;
            this._homePageController = new HomePageController(usuario);
        }

        private void OnLoad(object sender, EventArgs e)
        {

            InitializeComponent();

            SelecionarInterface(_homePageController.FiltrarLogin());
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_confirmacaoSaidaExibida)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _confirmacaoSaidaExibida = true;
                    Application.Exit();
                }
            }
        }

        private void SelecionarInterface(string tipoUsuarioLogado)
        {

            switch (tipoUsuarioLogado)
            {
                case "Desenvolvedor":
                    CriarPainelDev();
                    break;
                case "Tech Leader":
                    CriarPainelTechL();
                    break;
                case "Administrador":
                    CriarPainelAdm();
                    break;
            }

            Controls.Add(_painelHomePage);
        }

        private void CriarPainelDev()
        {
            _painelHomePage.Controls.Clear();

        }

        private void CriarPainelTechL()
        {
            _painelHomePage.Controls.Clear();

        }

        #region Painel Administrador
        private void CriarPainelAdm()
        {
            _painelHomePage.Controls.Clear();

            Button btnVisualizarTarefas = new Button();
            btnVisualizarTarefas.Size = new Size(200, 30);
            btnVisualizarTarefas.Location = new Point(10, 10);
            btnVisualizarTarefas.Anchor = AnchorStyles.Right;
            btnVisualizarTarefas.Text = "Visualizar Tarefas";
            btnVisualizarTarefas.Click += OnClickVisualizarTarefas;

            Button btnVisualizarUsuarios = new Button();
            btnVisualizarUsuarios.Size = new Size(200, 30);
            btnVisualizarUsuarios.Location = new Point(10, 50);
            btnVisualizarUsuarios.Anchor = AnchorStyles.Right;
            btnVisualizarUsuarios.Text = "Visualizar Usuários";
            btnVisualizarUsuarios.Click += OnClickVisualizarUsuarios;

            Button btnAdicionarProjeto = new Button();
            btnAdicionarProjeto.Size = new Size(200, 30);
            btnAdicionarProjeto.Location = new Point(10, 90);
            btnAdicionarProjeto.Anchor = AnchorStyles.Right;
            btnAdicionarProjeto.Text = "Adicionar Projeto";
            btnAdicionarProjeto.Click += OnClickAdicionarProjetos;

            Button btnVisualizarProjeto = new Button();
            btnVisualizarProjeto.Size = new Size(200, 30);
            btnVisualizarProjeto.Location = new Point(10, 130);
            btnVisualizarProjeto.Anchor = AnchorStyles.Right;
            btnVisualizarProjeto.Text = "Visualizar Projetos";
            btnVisualizarProjeto.Click += OnClickVisualizarProjetos;

            Button btnCadastrarTechLeader = new Button();
            btnCadastrarTechLeader.Size = new Size(200, 30);
            btnCadastrarTechLeader.Location = new Point(10, 170);
            btnCadastrarTechLeader.Anchor = AnchorStyles.Right;
            btnCadastrarTechLeader.Text = "Cadastrar Tech Leader";
            btnCadastrarTechLeader.Click += OnClickCadastrarTechLeader;

            _painelHomePage.Controls.Add(btnVisualizarTarefas);
            _painelHomePage.Controls.Add(btnVisualizarUsuarios);
            _painelHomePage.Controls.Add(btnAdicionarProjeto);
            _painelHomePage.Controls.Add(btnVisualizarProjeto);
            _painelHomePage.Controls.Add(btnCadastrarTechLeader);
        }


        private void OnClickVisualizarTarefas(object sender, EventArgs e)
        {
            TabelaVisualizarTarefas telaVisualizarTarefas = new TabelaVisualizarTarefas();
            telaVisualizarTarefas.ShowDialog();
        }

        private void OnClickVisualizarUsuarios(object sender, EventArgs e)
        {
            TabelaVisualizarUsuarios telaVisualizarUsuarios = new TabelaVisualizarUsuarios();
            telaVisualizarUsuarios.ShowDialog();
        }

        private void OnClickAdicionarProjetos(object sender, EventArgs e)
        {
            JanelaAdicionarProjeto telaAdicionarProjeto = new JanelaAdicionarProjeto();
            telaAdicionarProjeto.ShowDialog();
        }

        private void OnClickVisualizarProjetos(object sender, EventArgs e)
        {
            TabelaVisualizarProjetos telaVisualizarProjetos = new TabelaVisualizarProjetos();
            telaVisualizarProjetos.ShowDialog();
        }

        private void OnClickCadastrarTechLeader(object sender, EventArgs e)
        {
            JanelaCadastrarTechLeader telaCadastrarTechLeader = new JanelaCadastrarTechLeader();
            telaCadastrarTechLeader.ShowDialog();
        } 
        #endregion

        private void OnClickLogout(object sender, EventArgs e)
        {
            _confirmacaoSaidaExibida = true;
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();

            this.Close();
        }
    }
}
