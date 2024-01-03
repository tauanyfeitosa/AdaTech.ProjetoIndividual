using AdaTech.ProjetoIndividual.GerenciadorTarefas.Controllers;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;
using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views
{
    internal partial class TelaLogin : Form
    {
        private TelaLoginController _telaLoginController;

        internal TelaLogin()
        {
            InitializeComponent();
            _telaLoginController = new TelaLoginController(this);
        }

        private void OnClickEntrar(object sender, EventArgs e)
        {
            string usuarioDigitado = txtUsuario.Text;
            string senhaDigitada = txtSenha.Text;

            if (_telaLoginController.RealizarLogin())
            {
                this.Hide();
            }
        }
    }
}
