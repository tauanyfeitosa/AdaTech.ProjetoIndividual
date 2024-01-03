using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios
{
    internal abstract class Usuario
    {
        private string _nome;
        private string _email;
        private string _senha;
        private string _cpf;
        private string _dataAdmissao;
        private string _dataDemissao;
        private string _dataNascimento;
        private string _genero;
        private bool _ativo;

        internal string Nome { get => _nome; set => _nome = value; }
        internal string Email { get => _email; set => _email = value; }
        internal string Senha { get => _senha; set => _senha = value; }
        internal string Cpf { get => _cpf; set => _cpf = value; }
        internal string DataAdmissao { get => _dataAdmissao; set => _dataAdmissao = value; }
        internal string DataDemissao { get => _dataDemissao; set => _dataDemissao = value; }
        internal string DataNascimento { get => _dataNascimento; set => _dataNascimento = value; }
        internal string Genero { get => _genero; set => _genero = value; }
        internal bool Ativo { get => _ativo; set => _ativo = value; }


        internal Usuario(string nome, string email, string senha, string cpf, string dataAdmissao, string dataNascimento, string genero, string dataDemissao = null)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Cpf = cpf;
            DataAdmissao = dataAdmissao;
            DataDemissao = dataDemissao;
            DataNascimento = dataNascimento;
            Genero = genero;

            if (dataDemissao == null)
            {
                Ativo = true;
            }
            else
            {
                Ativo = false;
            }
        }
    }
}
