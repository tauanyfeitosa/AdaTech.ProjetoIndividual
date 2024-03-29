﻿using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.ProjetosBusiness;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios
{
    internal abstract class Usuario
    {
        private string _nome;
        private string _email;
        private string _senha;
        private string _cpf;
        private bool _ativo;

        public string Nome { get => _nome; set => _nome = value; }
        internal string Email { get => _email; set => _email = value; }
        internal string Senha { get => _senha; set => _senha = value; }
        internal string Cpf { get => _cpf; set => _cpf = value; }
        public bool Ativo { get => _ativo; set => _ativo = value; }

        public string Cargo
        {
            get
            {
                if (this is Administrador)
                {
                    return "Administrador";
                }
                else if (this is TechLeader)
                {
                    return "Tech Leader";
                }
                else
                {
                    return "Desenvolvedor";
                }
            }
        }

        public Projetos Projetos
        {
            get
            {
                if (this is TechLeader)
                {
                    return ((TechLeader)this).Projeto;
                }
                else if (this is Desenvolvedor)
                {
                    return ((Desenvolvedor)this).Projeto;
                }
                else
                {
                    return null;
                }
            }
        }

        public string NomeEstilo
        {
            get
            {
                return $"{Nome} - {Cpf} - {Cargo}";
            }
        }

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
