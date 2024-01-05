using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.ProjetosBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.TabelasDetalhesHomePage;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.JanelasHomePage
{
    internal partial class TabelaVisualizarUsuarios : Form
    {
        private DataGridView dataGridViewUsuarios = new DataGridView();
        private List<Usuario> usuarios;
        private Usuario usuario;

        internal TabelaVisualizarUsuarios(Usuario usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            InicializarDataGridView();
            CarregarUsuarios();
        }

        private void InicializarDataGridView()
        {
            dataGridViewUsuarios.Dock = DockStyle.Fill;
            dataGridViewUsuarios.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
            colNome.DataPropertyName = "Nome";
            colNome.HeaderText = "Nome";
            dataGridViewUsuarios.Columns.Add(colNome);

            DataGridViewTextBoxColumn colCargo = new DataGridViewTextBoxColumn();
            colCargo.DataPropertyName = "Cargo";
            colCargo.HeaderText = "Cargo";
            dataGridViewUsuarios.Columns.Add(colCargo);

            DataGridViewTextBoxColumn colAtivo = new DataGridViewTextBoxColumn();
            colAtivo.DataPropertyName = "Ativo";
            colAtivo.HeaderText = "Ativo";
            dataGridViewUsuarios.Columns.Add(colAtivo);

            dataGridViewUsuarios.CellClick += DataGridViewUsuarios_CellClick;

            Controls.Add(dataGridViewUsuarios);
        }

        private void CarregarUsuarios()
        {
            try
            {
                usuarios = new List<Usuario>();

                if (usuario is TechLeader tl)
                {
                    var usuariosPorTechLeader = UsuarioData.ListarUsuarios(tl.Projetos);
                    usuarios.AddRange(usuariosPorTechLeader.Item2);
                    usuarios.AddRange(usuariosPorTechLeader.Item1);
                } else if (usuario is Desenvolvedor d)
                {
                    var usuariosPorDesenvolvedor = UsuarioData.ListarUsuarios(d.Projetos);
                    usuarios.AddRange(usuariosPorDesenvolvedor.Item2);
                    usuarios.AddRange(usuariosPorDesenvolvedor.Item1);
                } else
                {
                    usuarios.AddRange(UsuarioData.Desenvolvedores);
                    usuarios.AddRange(UsuarioData.TechLeaders);
                    usuarios.AddRange(UsuarioData.Administrador);
                }
                

                if (usuarios.Count > 0)
                {
                    dataGridViewUsuarios.DataSource = usuarios;
                }
                else
                {
                    MessageBox.Show("A lista de usuários está vazia.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários: {ex.Message}");
            }
        }

        private void DataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < usuarios.Count)
            {
                Usuario usuarioSelecionado = usuarios[e.RowIndex];
                MostrarDetalhesUsuario(usuarioSelecionado);
            }
        }

        private void MostrarDetalhesUsuario(Usuario usuario)
        {
            List<Tarefas> tarefasResponsavel = TarefaData.ObterTarefasPorResponsavel(usuario);

            DetalhesUsuarios detalhesForm = new DetalhesUsuarios(usuario, tarefasResponsavel);
            detalhesForm.ShowDialog();
        }
    }
}
