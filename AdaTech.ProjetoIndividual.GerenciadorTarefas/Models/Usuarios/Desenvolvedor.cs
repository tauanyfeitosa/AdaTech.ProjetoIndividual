using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios
{
    internal sealed class Desenvolvedor: Usuario
    {
        internal Desenvolvedor(string nome, string email, string senha, string cpf, DateTime dataAdmissao, DateTime dataNascimento, string genero, DateTime? dataDemissao = null) 
            : base(nome, email, senha, cpf, dataAdmissao, dataNascimento, genero, dataDemissao)
        {
        }

        internal void ListarTarefas()
        {

        }

        internal void EditarTarefa()
        {

        }

        internal void ExcluirTarefa()
        {

        }

        internal void EditarDesenvolvedor()
        {

        }

        internal void ExcluirDesenvolvedor()
        {

        }

        internal void ListarDesenvolvedores()
        {

        }

        internal void ListarTarefasConcluidas()
        {

        }

        internal void ListarTarefasPendentes()
        {

        }

        internal void ListarTarefasAtrasadas()
        {

        }

        internal void ListarTarefasEmAndamento()
        {

        }

        internal void ListarTarefasCanceladas()
        {

        }

        internal void CriarTarefas()
        {

        }
    }
}
