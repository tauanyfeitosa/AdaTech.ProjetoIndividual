using AdaTech.ProjetoIndividual.GerenciadorTarefas.Controllers;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;
using System;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views
{
    internal partial class TelaLogin : Form
    {
        private readonly TelaLoginController _telaLoginController;


        internal TelaLogin()
        {
            InitializeComponent();
            _telaLoginController = new TelaLoginController(this);
        }

        private void OnClickEntrar(object sender, EventArgs e)
        {

            if (_telaLoginController.RealizarLogin())
            {
                this.Hide();
                HomePage homePage = new HomePage(UsuarioData.SelecionarUsuario(TxtUsuario.Text));
                homePage.ShowDialog();
            }
        }
    }
}
