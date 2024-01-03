using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views
{
    partial class TelaLogin
    {
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblSenha;
        private TextBox txtSenha;
        private Button btnLogin;
        private Panel painelLogin;

        internal TextBox TxtUsuario => txtUsuario;
        internal TextBox TxtSenha => txtSenha;

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
            WindowState = FormWindowState.Maximized;
            BackColor = Color.FromArgb(200, 162, 200);

            painelLogin = new Panel
            {
                Size = new Size(ClientSize.Width + 200, ClientSize.Height),
                Location = new Point(ClientSize.Width - 400, ClientSize.Height - 300),
                BackColor = Color.FromArgb(255, 228, 196),
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.None
            };

            this.lblUsuario = new Label
            {
                AutoSize = true,
                Location = new Point(10, 20),
                Text = "Usuário:"
            };

            this.txtUsuario = new TextBox
            {
                Location = new Point(120, 20),
                Size = new Size(150, 20)
            };

            this.lblSenha = new Label
            {
                AutoSize = true,
                Location = new Point(10, 50),
                Text = "Senha:"
            };

            this.txtSenha = new TextBox
            {
                Location = new Point(120, 50),
                Size = new Size(150, 20),
                PasswordChar = '*'
            };

            this.btnLogin = new Button
            {
                Location = new Point(120, 80),
                Size = new Size(75, 23),
                Text = "Login"
            };

            this.btnLogin.Click += OnClickEntrar;

            painelLogin.Controls.Add(this.lblUsuario);
            painelLogin.Controls.Add(this.txtUsuario);
            painelLogin.Controls.Add(this.lblSenha);
            painelLogin.Controls.Add(this.txtSenha);
            painelLogin.Controls.Add(this.btnLogin);

            this.Controls.Add(painelLogin);
        }

        #endregion
    }
}
