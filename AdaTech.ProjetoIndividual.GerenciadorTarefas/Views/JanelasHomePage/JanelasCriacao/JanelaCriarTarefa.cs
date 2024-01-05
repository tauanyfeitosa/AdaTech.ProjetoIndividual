using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    internal partial class JanelaCriarTarefa : Form
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

        internal JanelaCriarTarefa(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            ConfigurarControles();
            CarregarUsuarios();
            CarregarTarefasRelacionadas();

            this.WindowState = FormWindowState.Maximized;
        }

        private void ConfigurarControles()
        {
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

        private void DateTimePickerDataInicio_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            if (dtp.Value > DateTime.Today)
            {
                dtp.Value = DateTime.Today;
            }
        }

        private void DateTimePickerFim_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;

            if (dtp.Value < dateTimePickerDataInicio.Value)
            {
                dtp.Value = dateTimePickerDataInicio.Value;
            }
        }

        private void CarregarUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            if (usuarioLogado is TechLeader)
            {
                Tuple<List<Desenvolvedor>, List<TechLeader>> usuarios = UsuarioData.ListarUsuariosAtivos(usuarioLogado.Projetos);
                listaUsuarios.AddRange(usuarios.Item1);
                listaUsuarios.AddRange(usuarios.Item2);
            }
            else
            {
                listaUsuarios.Add(usuarioLogado);
            }

            cmbUsuario.DataSource = listaUsuarios;
            cmbUsuario.DisplayMember = "NomeEstilo";
        }


        private void CarregarTarefasRelacionadas()
        {
            List<Tarefas> tarefas = TarefaData.Listar(usuarioLogado.Projetos);

            listBoxTarefasRelacionadas.DataSource = tarefas;
            listBoxTarefasRelacionadas.DisplayMember = "NomeEstilo";
            listBoxTarefasRelacionadas.SelectionMode = SelectionMode.MultiSimple;
        }


        private void btnCadastrarTarefa_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            string descricao = txtDescricao.Text;
            DateTime dataInicio = dateTimePickerDataInicio.Value;
            PrioridadeTarefa prioridade = (PrioridadeTarefa)cmbPrioridade.SelectedItem;
            Usuario usuarioResponsavel = cmbUsuario.SelectedItem as Usuario;
            DateTime dataFim = dateTimePickerFim.Value;

            List<int> idTarefasRelacionadas = ObterIdsTarefasRelacionadas();

            if (TarefaData.AdicionarTarefa(titulo, descricao, dataInicio, prioridade, usuarioResponsavel, dataFim, idTarefasRelacionadas))
            {
                lblMensagem.Text = "Tarefa cadastrada com sucesso!";
                lblMensagem.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensagem.Text = "Erro ao cadastrar a tarefa. Verifique os campos!";
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }

            LimparCampos();
        }

        private List<int> ObterIdsTarefasRelacionadas()
        {
            List<int> ids = new List<int>();

            foreach (Tarefas tarefa in listBoxTarefasRelacionadas.SelectedItems)
            {
                ids.Add(tarefa.Id);
            }

            return ids;
        }

        private void LimparCampos()
        {
            txtTitulo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            dateTimePickerDataInicio.Value = DateTime.Today;
            cmbPrioridade.SelectedIndex = -1;
            cmbUsuario.SelectedIndex = -1;
            dateTimePickerFim.Value = DateTime.Today;
            listBoxTarefasRelacionadas.ClearSelected();
        }
    }
}
