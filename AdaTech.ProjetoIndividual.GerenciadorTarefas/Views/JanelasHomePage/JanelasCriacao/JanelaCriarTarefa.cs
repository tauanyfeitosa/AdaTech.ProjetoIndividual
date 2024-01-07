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

        internal JanelaCriarTarefa(Usuario usuario)
        {
            this.usuarioLogado = usuario;
            InitializeComponent();
            CarregarUsuarios();
            CarregarTarefasRelacionadas();

            this.WindowState = FormWindowState.Maximized;
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
