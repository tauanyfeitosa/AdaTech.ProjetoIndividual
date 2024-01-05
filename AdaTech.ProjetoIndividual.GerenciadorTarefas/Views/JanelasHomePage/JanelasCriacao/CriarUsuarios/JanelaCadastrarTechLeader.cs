using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.ProjetosBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    public partial class JanelaCadastrarTechLeader : Form
    {
        private TextBox txtSenha;
        private TextBox txtNome;
        private TextBox txtCpf;
        private TextBox txtEmail;
        private ComboBox cmbProjetos;
        private Button btnCadastrarTechLeader;

        public JanelaCadastrarTechLeader()
        {
            InitializeComponent();
            ConfigurarControles();
            CarregarProjetos();
        }

        private void ConfigurarControles()
        {
            txtSenha = new TextBox();
            txtSenha.Location = new System.Drawing.Point(20, 20);
            txtSenha.Size = new System.Drawing.Size(200, 25);
            Controls.Add(txtSenha);

            Label lblSenha = new Label();
            lblSenha.Text = "Senha:";
            lblSenha.Location = new System.Drawing.Point(230, 20);
            lblSenha.AutoSize = true;
            Controls.Add(lblSenha);

            txtNome = new TextBox();
            txtNome.Location = new System.Drawing.Point(20, 60);
            txtNome.Size = new System.Drawing.Size(200, 25);
            Controls.Add(txtNome);

            Label lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.Location = new System.Drawing.Point(230, 60);
            lblNome.AutoSize = true;
            Controls.Add(lblNome);

            txtCpf = new TextBox();
            txtCpf.Location = new System.Drawing.Point(20, 100);
            txtCpf.Size = new System.Drawing.Size(200, 25);
            Controls.Add(txtCpf);

            Label lblCpf = new Label();
            lblCpf.Text = "CPF:";
            lblCpf.Location = new System.Drawing.Point(230, 100);
            lblCpf.AutoSize = true;
            Controls.Add(lblCpf);

            txtEmail = new TextBox();
            txtEmail.Location = new System.Drawing.Point(20, 140);
            txtEmail.Size = new System.Drawing.Size(200, 25);
            Controls.Add(txtEmail);

            Label lblEmail = new Label();
            lblEmail.Text = "E-mail:";
            lblEmail.Location = new System.Drawing.Point(230, 140);
            lblEmail.AutoSize = true;
            Controls.Add(lblEmail);

            cmbProjetos = new ComboBox();
            cmbProjetos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProjetos.Location = new System.Drawing.Point(20, 180);
            cmbProjetos.Size = new System.Drawing.Size(200, 25);
            Controls.Add(cmbProjetos);

            Label lblProjetos = new Label();
            lblProjetos.Text = "Projetos:";
            lblProjetos.Location = new System.Drawing.Point(230, 180);
            lblProjetos.AutoSize = true;
            Controls.Add(lblProjetos);

            btnCadastrarTechLeader = new Button();
            btnCadastrarTechLeader.Text = "Cadastrar TechLeader";
            btnCadastrarTechLeader.Location = new System.Drawing.Point(20, 220);
            btnCadastrarTechLeader.Click += btnCadastrarTechLeader_Click;
            Controls.Add(btnCadastrarTechLeader);
        }

        private void CarregarProjetos()
        {
            List<Projetos> projetos = ProjetoData.Listar();

            cmbProjetos.DataSource = projetos;
            cmbProjetos.DisplayMember = "NomeProjeto";
        }

        private void btnCadastrarTechLeader_Click(object sender, EventArgs e)
        {
            string senha = txtSenha.Text;
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;
            string email = txtEmail.Text;
            Projetos projetoSelecionado = cmbProjetos.SelectedItem as Projetos;

            if (projetoSelecionado == null)
            {
                MessageBox.Show("Selecione um projeto válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsuarioData.VerificarUsuarioExistenteCpf(cpf))
            {
                MessageBox.Show("CPF já cadastrado no sistema. Escolha um CPF diferente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsuarioData.VerificarUsuarioExistenteEmail(email))
            {
                MessageBox.Show("E-mail já cadastrado no sistema. Escolha um e-mail diferente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UsuarioData.AdicionarTechLeader(senha, nome, cpf, email, projetoSelecionado);

            LimparCampos();

            MessageBox.Show("TechLeader cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void LimparCampos()
        {
            txtSenha.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbProjetos.SelectedIndex = -1;
        }
    }
}
