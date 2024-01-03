using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios
{
    internal sealed class TechLeader: Usuario
    {
        internal TechLeader(string nome, string email, string senha, string cpf, string dataAdmissao, string dataNascimento, string genero, string dataDemissao = null) 
            : base(nome, email, senha, cpf, dataAdmissao, dataNascimento, genero, dataDemissao)
        {
        }

        internal void CadastrarDesenvolvedor()
        {

        }

        internal void CadastrarTarefa()
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

        internal void ListarTarefas()
        {

        }

        internal void ListarDesenvolvedores()
        {

        }
    }
}
