using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views
{
    partial class HomePage
    {
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

            Controls.Add(_lblBemVindo);
            Controls.Add(_btnLogout);
        }

        #endregion
    }
}