using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System;
using System.Windows.Forms;
using System.Linq;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    partial class JanelaCriarTarefa
    {
        private TextBox txtTitulo;
        private TextBox txtDescricao;
        private DateTimePicker dateTimePickerDataInicio;
        private ComboBox cmbPrioridade;
        private ComboBox cmbUsuario;
        private DateTimePicker dateTimePickerFim;
        private ListBox listBoxTarefasRelacionadas;
        private Button btnCadastrarTarefa;
        private Label lblMensagem;
        private Usuario usuarioLogado;
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "JanelaCriarTarefa";

            txtTitulo = new TextBox();
            txtTitulo.Location = new System.Drawing.Point(20, 20);
            txtTitulo.Size = new System.Drawing.Size(300, 25);
            Controls.Add(txtTitulo);

            Label lblTitulo = new Label();
            lblTitulo.Text = "Título:";
            lblTitulo.Location = new System.Drawing.Point(330, 20);
            lblTitulo.AutoSize = true;
            Controls.Add(lblTitulo);

            txtDescricao = new TextBox();
            txtDescricao.Location = new System.Drawing.Point(20, 60);
            txtDescricao.Size = new System.Drawing.Size(300, 100);
            Controls.Add(txtDescricao);

            Label lblDescricao = new Label();
            lblDescricao.Text = "Descrição:";
            lblDescricao.Location = new System.Drawing.Point(330, 60);
            lblDescricao.AutoSize = true;
            Controls.Add(lblDescricao);

            dateTimePickerDataInicio = new DateTimePicker();
            dateTimePickerDataInicio.Location = new System.Drawing.Point(20, 180);
            dateTimePickerDataInicio.Size = new System.Drawing.Size(300, 25);
            dateTimePickerDataInicio.MaxDate = DateTime.Today;
            dateTimePickerDataInicio.ValueChanged += DateTimePickerDataInicio_ValueChanged;
            Controls.Add(dateTimePickerDataInicio);

            Label lblDataInicio = new Label();
            lblDataInicio.Text = "Data de Início:";
            lblDataInicio.Location = new System.Drawing.Point(330, 180);
            lblDataInicio.AutoSize = true;
            Controls.Add(lblDataInicio);

            cmbPrioridade = new ComboBox();
            cmbPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridade.Location = new System.Drawing.Point(20, 220);
            cmbPrioridade.Size = new System.Drawing.Size(300, 25);
            cmbPrioridade.Items.AddRange(Enum.GetValues(typeof(PrioridadeTarefa)).OfType<object>().ToArray());
            Controls.Add(cmbPrioridade);

            Label lblPrioridade = new Label();
            lblPrioridade.Text = "Prioridade:";
            lblPrioridade.Location = new System.Drawing.Point(330, 220);
            lblPrioridade.AutoSize = true;
            Controls.Add(lblPrioridade);

            cmbUsuario = new ComboBox();
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.Location = new System.Drawing.Point(20, 260);
            cmbUsuario.Size = new System.Drawing.Size(300, 25);
            Controls.Add(cmbUsuario);

            Label lblUsuario = new Label();
            lblUsuario.Text = "Usuário Responsável:";
            lblUsuario.Location = new System.Drawing.Point(330, 260);
            lblUsuario.AutoSize = true;
            Controls.Add(lblUsuario);

            dateTimePickerFim = new DateTimePicker();
            dateTimePickerFim.Location = new System.Drawing.Point(20, 300);
            dateTimePickerFim.Size = new System.Drawing.Size(300, 25);
            dateTimePickerFim.MinDate = DateTime.Today;
            dateTimePickerFim.ValueChanged += DateTimePickerFim_ValueChanged;
            Controls.Add(dateTimePickerFim);

            Label lblFim = new Label();
            lblFim.Text = "Data de Término:";
            lblFim.Location = new System.Drawing.Point(330, 300);
            lblFim.AutoSize = true;
            Controls.Add(lblFim);

            listBoxTarefasRelacionadas = new ListBox();
            listBoxTarefasRelacionadas.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular);
            listBoxTarefasRelacionadas.Location = new System.Drawing.Point(20, 340);
            listBoxTarefasRelacionadas.Size = new System.Drawing.Size(300, 120);
            Controls.Add(listBoxTarefasRelacionadas);

            Label lblTarefasRelacionadas = new Label();
            lblTarefasRelacionadas.Text = "Tarefas Relacionadas:";
            lblTarefasRelacionadas.Location = new System.Drawing.Point(330, 340);
            lblTarefasRelacionadas.AutoSize = true;
            Controls.Add(lblTarefasRelacionadas);

            btnCadastrarTarefa = new Button();
            btnCadastrarTarefa.Text = "Cadastrar Tarefa";
            btnCadastrarTarefa.Location = new System.Drawing.Point(20, 480);
            btnCadastrarTarefa.Click += btnCadastrarTarefa_Click;
            Controls.Add(btnCadastrarTarefa);

            lblMensagem = new Label();
            lblMensagem.Location = new System.Drawing.Point(20, 520);
            lblMensagem.AutoSize = true;
            Controls.Add(lblMensagem);
        }

        #endregion
    }
}