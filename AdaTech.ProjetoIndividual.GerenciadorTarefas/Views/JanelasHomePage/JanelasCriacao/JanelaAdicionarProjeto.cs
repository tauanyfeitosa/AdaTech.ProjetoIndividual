using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    public partial class JanelaAdicionarProjeto : Form
    {
        public JanelaAdicionarProjeto()
        {
            InitializeComponent();
        }

        private void btnAdicionarProjeto_Click(object sender, EventArgs e)
        {
            string nomeProjeto = txtNomeProjeto.Text;
            string descricaoProjeto = txtDescricaoProjeto.Text;
            DateTime dataInicio = dateTimePickerDataInicio.Value;

            if (ProjetoData.AdicionarProjeto(nomeProjeto, descricaoProjeto, dataInicio))
            {
                lblMensagem.Text = "Projeto adicionado com sucesso!";
                lblMensagem.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensagem.Text = "Erro ao adicionar o projeto. Verifique os campos!";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }

            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNomeProjeto.Text = string.Empty;
            txtDescricaoProjeto.Text = string.Empty;
            dateTimePickerDataInicio.Value = DateTime.Now.Date;
        }
    }
}
