using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.TabelasDetalhesHomePage
{
    internal partial class DetalhesTarefas : Form
    {
        internal DetalhesTarefas(Tarefas tarefa, Usuario usuario)
        {
            this._usuario = usuario;
            _tarefa = tarefa;
            InitializeComponent();
        }

        private Label CriarLabel(string texto, int x, int y)
        {
            Label label = new Label();
            label.Text = texto;
            label.Font = new Font("Arial", 12, FontStyle.Regular);
            label.Location = new Point(x, y);
            label.AutoSize = true;
            Controls.Add(label);
            return label;
        }

        private void AtualizarStatusTarefa(ComboBox cmbStatus)
        {
            if (_usuario is Desenvolvedor && _tarefa.Responsavel == _usuario && _tarefa.Status != StatusTarefa.Concluida)
            {
                if (Enum.TryParse(cmbStatus.SelectedItem.ToString(), out StatusTarefa novoStatus))
                {
                    TarefaData.AlterarStatus(_tarefa, novoStatus);
                    MessageBox.Show($"Status da tarefa atualizado para: {novoStatus}");
                }
                else
                {
                    MessageBox.Show("Escolha um status válido para a tarefa.");
                }
            }
        }
    }
}
