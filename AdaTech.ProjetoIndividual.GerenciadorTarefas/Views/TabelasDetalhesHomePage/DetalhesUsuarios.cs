using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Views.TabelasDetalhesHomePage
{
    internal partial class DetalhesUsuarios : Form
    {
        internal DetalhesUsuarios(Usuario usuario, List<Tarefas> tarefas)
        {
            _usuario = usuario;
            _tarefas = tarefas;
            InitializeComponent();
        }
    }
}
