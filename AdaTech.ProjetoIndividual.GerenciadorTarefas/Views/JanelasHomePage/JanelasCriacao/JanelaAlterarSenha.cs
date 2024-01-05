using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;
using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    internal partial class JanelaAlterarSenha : Form
    {
        private TextBox txtSenhaAntiga;
        private TextBox txtNovaSenha;
        private TextBox txtConfirmarSenha;
        private Button btnAlterarSenha;
        private Usuario usuario;

        internal JanelaAlterarSenha(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            ConfigurarControles();
        }

        private void ConfigurarControles()
        {
            txtSenhaAntiga = new TextBox();
            txtSenhaAntiga.Location = new System.Drawing.Point(20, 20);
            txtSenhaAntiga.Size = new System.Drawing.Size(200, 25);
            txtSenhaAntiga.PasswordChar = '*';
            Controls.Add(txtSenhaAntiga);

            Label lblSenhaAntiga = new Label();
            lblSenhaAntiga.Text = "Senha Antiga:";
            lblSenhaAntiga.Location = new System.Drawing.Point(230, 20);
            lblSenhaAntiga.AutoSize = true;
            Controls.Add(lblSenhaAntiga);

            txtNovaSenha = new TextBox();
            txtNovaSenha.Location = new System.Drawing.Point(20, 60);
            txtNovaSenha.Size = new System.Drawing.Size(200, 25);
            txtNovaSenha.PasswordChar = '*';
            Controls.Add(txtNovaSenha);

            Label lblNovaSenha = new Label();
            lblNovaSenha.Text = "Nova Senha:";
            lblNovaSenha.Location = new System.Drawing.Point(230, 60);
            lblNovaSenha.AutoSize = true;
            Controls.Add(lblNovaSenha);

            txtConfirmarSenha = new TextBox();
            txtConfirmarSenha.Location = new System.Drawing.Point(20, 100);
            txtConfirmarSenha.Size = new System.Drawing.Size(200, 25);
            txtConfirmarSenha.PasswordChar = '*';
            Controls.Add(txtConfirmarSenha);

            Label lblConfirmarSenha = new Label();
            lblConfirmarSenha.Text = "Confirmar Senha:";
            lblConfirmarSenha.Location = new System.Drawing.Point(230, 100);
            lblConfirmarSenha.AutoSize = true;
            Controls.Add(lblConfirmarSenha);

            btnAlterarSenha = new Button();
            btnAlterarSenha.Text = "Alterar Senha";
            btnAlterarSenha.Location = new System.Drawing.Point(20, 120);
            btnAlterarSenha.Click += btnAlterarSenha_Click;
            Controls.Add(btnAlterarSenha);
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
