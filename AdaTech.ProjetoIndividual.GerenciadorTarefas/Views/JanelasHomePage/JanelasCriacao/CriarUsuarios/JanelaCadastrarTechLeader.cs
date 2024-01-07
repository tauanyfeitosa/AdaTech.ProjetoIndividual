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

        public JanelaCadastrarTechLeader()
        {
            InitializeComponent();
            CarregarProjetos();
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
