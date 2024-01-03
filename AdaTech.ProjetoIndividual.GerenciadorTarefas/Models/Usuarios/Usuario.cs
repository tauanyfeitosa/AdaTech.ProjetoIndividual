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
        private bool _ativo;

        internal string Nome { get => _nome; set => _nome = value; }
        internal string Email { get => _email; set => _email = value; }
        internal string Senha { get => _senha; set => _senha = value; }
        internal string Cpf { get => _cpf; set => _cpf = value; }
        internal bool Ativo { get => _ativo; set => _ativo = value; }


        internal Usuario(string nome, string email, string senha, string cpf, bool ativo = true)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Cpf = cpf;
            Ativo = ativo;
        }

        internal bool FazerLogin(string cpf, string senha)
        {
            if (Cpf == cpf && Senha == senha)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
