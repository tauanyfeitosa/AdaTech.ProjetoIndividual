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

        #region Painel Desenvolvedor
        private void CriarPainelDev()
        {
            _painelHomePage.Controls.Clear();

            btnVisualizarTarefas.Size = new Size(200, 30);

            btnCriarTarefa.Size = new Size(200, 30);

            btnVisualizarUsuarios.Size = new Size(200, 30);

            btnAlterarSenha.Size = new Size(300, 30);

            _painelHomePage.Controls.Add(btnVisualizarTarefas);
            _painelHomePage.Controls.Add(btnAlterarSenha);
            _painelHomePage.Controls.Add(btnCriarTarefa);
            _painelHomePage.Controls.Add(btnVisualizarUsuarios);

        }
        #endregion

        #region Painel Tech Leader
        private void CriarPainelTechL()
        {
            _painelHomePage.Controls.Clear();

            btnCriarTarefa.Size = new Size(200, 30);

            btnVisualizarTarefas.Size = new Size(200, 30);

            btnVisualizarUsuarios.Size = new Size(200, 30);

            btnCadastrarDev.Size = new Size(200, 30);

            btnAlterarSenha.Size = new Size(300, 30);

            _painelHomePage.Controls.Add(btnCriarTarefa);
            _painelHomePage.Controls.Add(btnVisualizarTarefas);
            _painelHomePage.Controls.Add(btnVisualizarUsuarios);
            _painelHomePage.Controls.Add(btnCadastrarDev);
            _painelHomePage.Controls.Add(btnAlterarSenha);

        }
        #endregion

        #region Painel Administrador
        private void CriarPainelAdm()
        {
            _painelHomePage.Controls.Clear();

            btnVisualizarTarefas.Size = new Size(200, 30);

            btnVisualizarUsuarios.Size = new Size(200, 30);

            btnAdicionarProjeto.Size = new Size(200, 30);

            btnVisualizarProjeto.Size = new Size(200, 30);

            btnCadastrarTechLeader.Size = new Size(200, 30);

            _painelHomePage.Controls.Add(btnVisualizarTarefas);
            _painelHomePage.Controls.Add(btnVisualizarUsuarios);
            _painelHomePage.Controls.Add(btnAdicionarProjeto);
            _painelHomePage.Controls.Add(btnVisualizarProjeto);
            _painelHomePage.Controls.Add(btnCadastrarTechLeader);
        }

        #endregion

        #region OnClicks
        private void OnClickCriarTarefa(object sender, EventArgs e)
        {
            JanelaCriarTarefa telaCriarTarefa = new JanelaCriarTarefa(_usuarioLogado);
            telaCriarTarefa.ShowDialog();
        }

        private void OnClickCadastrarDev(object sender, EventArgs e)
        {
            JanelaCadastrarDev telaCadastrarDev = new JanelaCadastrarDev();
            telaCadastrarDev.ShowDialog();
        }

        private void OnClickAlterarSenha(object sender, EventArgs e)
        {
            JanelaAlterarSenha telaAlterarSenha = new JanelaAlterarSenha(_usuarioLogado);
            telaAlterarSenha.ShowDialog();
        }

        private void OnClickVisualizarTarefas(object sender, EventArgs e)
        {
            TabelaVisualizarTarefas telaVisualizarTarefas = new TabelaVisualizarTarefas(_usuarioLogado);
            telaVisualizarTarefas.ShowDialog();
        }

        private void OnClickVisualizarUsuarios(object sender, EventArgs e)
        {
            TabelaVisualizarUsuarios telaVisualizarUsuarios = new TabelaVisualizarUsuarios(_usuarioLogado);
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

        private void OnClickLogout(object sender, EventArgs e)
        {
            _confirmacaoSaidaExibida = true;
            TelaLogin telaLogin = new TelaLogin();
            telaLogin.Show();

            this.Close();
        } 
        #endregion
    }
}
