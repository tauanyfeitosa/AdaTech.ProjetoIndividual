using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;
using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    internal partial class JanelaAlterarSenha : Form
    {
        internal JanelaAlterarSenha(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            string senhaAntiga = txtSenhaAntiga.Text;
            string novaSenha = txtNovaSenha.Text;
            string confirmarSenha = txtConfirmarSenha.Text;

            if (!UsuarioData.VerificarSenhaAntiga(usuario, senhaAntiga))
            {
                MessageBox.Show("Senha antiga incorreta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (novaSenha != confirmarSenha)
            {
                MessageBox.Show("As novas senhas não coincidem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UsuarioData.AtualizarSenha(usuario, novaSenha);

            MessageBox.Show("Senha alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimparCampos();
        }

        private void LimparCampos()
        {
            txtSenhaAntiga.Text = string.Empty;
            txtNovaSenha.Text = string.Empty;
            txtConfirmarSenha.Text = string.Empty;
        }
    }
}
