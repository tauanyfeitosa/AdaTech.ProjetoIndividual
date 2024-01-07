using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    partial class JanelaCadastrarDev
    {
        private TextBox txtSenha;
        private TextBox txtNome;
        private TextBox txtCpf;
        private TextBox txtEmail;
        private ComboBox cmbProjetos;
        private Button btnCadastrarDev;
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
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.lblCpf = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.cmbProjetos = new System.Windows.Forms.ComboBox();
            this.lblProjetos = new System.Windows.Forms.Label();
            this.btnCadastrarDev = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(311, 44);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(200, 20);
            this.txtSenha.TabIndex = 0;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(230, 47);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 1;
            this.lblSenha.Text = "Senha:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(311, 80);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(200, 20);
            this.txtNome.TabIndex = 2;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(230, 87);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "Nome:";
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(311, 124);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(200, 20);
            this.txtCpf.TabIndex = 4;
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(230, 127);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(30, 13);
            this.lblCpf.TabIndex = 5;
            this.lblCpf.Text = "CPF:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(311, 164);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(230, 167);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "E-mail:";
            // 
            // cmbProjetos
            // 
            this.cmbProjetos.Location = new System.Drawing.Point(311, 205);
            this.cmbProjetos.Name = "cmbProjetos";
            this.cmbProjetos.Size = new System.Drawing.Size(200, 21);
            this.cmbProjetos.TabIndex = 8;
            // 
            // lblProjetos
            // 
            this.lblProjetos.AutoSize = true;
            this.lblProjetos.Location = new System.Drawing.Point(230, 205);
            this.lblProjetos.Name = "lblProjetos";
            this.lblProjetos.Size = new System.Drawing.Size(43, 13);
            this.lblProjetos.TabIndex = 9;
            this.lblProjetos.Text = "Projeto:";
            // 
            // btnCadastrarDev
            // 
            this.btnCadastrarDev.Location = new System.Drawing.Point(311, 307);
            this.btnCadastrarDev.Name = "btnCadastrarDev";
            this.btnCadastrarDev.Size = new System.Drawing.Size(169, 37);
            this.btnCadastrarDev.TabIndex = 10;
            this.btnCadastrarDev.Text = "Cadastrar Desenvolvedor";
            // 
            // JanelaCadastrarDev
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.lblCpf);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.cmbProjetos);
            this.Controls.Add(this.lblProjetos);
            this.Controls.Add(this.btnCadastrarDev);
            this.Name = "JanelaCadastrarDev";
            this.Text = "JanelaCadastrarDev";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblSenha;
        private Label lblNome;
        private Label lblCpf;
        private Label lblEmail;
        private Label lblProjetos;
    }
}