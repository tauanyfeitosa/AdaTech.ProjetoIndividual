using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    public partial class JanelaAdicionarProjeto : Form
    {
        private TextBox txtNomeProjeto;
        private TextBox txtDescricaoProjeto;
        private DateTimePicker dateTimePickerDataInicio;
        private Button btnAdicionarProjeto;
        private Label lblMensagem;

        public JanelaAdicionarProjeto()
        {
            InitializeComponent();
            ConfigurarControles();
        }

        private void ConfigurarControles()
        {
            txtNomeProjeto = new TextBox();
            txtNomeProjeto.Location = new System.Drawing.Point(20, 20);
            txtNomeProjeto.Size = new System.Drawing.Size(200, 25);
            Controls.Add(txtNomeProjeto);

            Label lblNome = new Label();
            lblNome.Text = "Nome do Projeto:";
            lblNome.Location = new System.Drawing.Point(230, 20);
            lblNome.AutoSize = true;
            Controls.Add(lblNome);

            txtDescricaoProjeto = new TextBox();
            txtDescricaoProjeto.Location = new System.Drawing.Point(20, 60);
            txtDescricaoProjeto.Size = new System.Drawing.Size(200, 100);
            Controls.Add(txtDescricaoProjeto);

            Label lblDescricao = new Label();
            lblDescricao.Text = "Descrição do Projeto:";
            lblDescricao.Location = new System.Drawing.Point(230, 60);
            lblDescricao.AutoSize = true;
            Controls.Add(lblDescricao);

            dateTimePickerDataInicio = new DateTimePicker();
            dateTimePickerDataInicio.Location = new System.Drawing.Point(20, 180);
            dateTimePickerDataInicio.MaxDate = DateTime.Now;
            Controls.Add(dateTimePickerDataInicio);

            Label lblDataInicio = new Label();
            lblDataInicio.Text = "Data de Início:";
            lblDataInicio.Location = new System.Drawing.Point(230, 180);
            lblDataInicio.AutoSize = true;
            Controls.Add(lblDataInicio);

            btnAdicionarProjeto = new Button();
            btnAdicionarProjeto.Text = "Adicionar Projeto";
            btnAdicionarProjeto.Location = new System.Drawing.Point(20, 220);
            btnAdicionarProjeto.Click += btnAdicionarProjeto_Click;
            Controls.Add(btnAdicionarProjeto);

            lblMensagem = new Label();
            lblMensagem.Location = new System.Drawing.Point(20, 260);
            lblMensagem.AutoSize = true;
            Controls.Add(lblMensagem);
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
