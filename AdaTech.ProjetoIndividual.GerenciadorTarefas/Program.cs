using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Views;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            UsuarioData.CarregarDados();
            TarefaData.CarregarDados();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaLogin());
        }
    }
}
