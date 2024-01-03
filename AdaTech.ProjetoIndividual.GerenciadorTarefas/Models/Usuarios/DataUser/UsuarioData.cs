using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser
{
    internal static class UsuarioData
    {
        private static List<Desenvolvedor> _desenvolvedores = new List<Desenvolvedor>();
        private static List<TechLeader> _techLeaders = new List<TechLeader>();
        private static List<Administrador> _administrador = new List<Administrador>();

        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "\\Data";
        private static readonly string _FILE_PATH_DESENVOLVEDOR = Path.Combine(_DIRECTORY_PATH, "Desenvolvedor.txt");
        private static readonly string _FILE_PATH_TECH_LEADER = Path.Combine(_DIRECTORY_PATH, "TechLeader.txt");
        private static readonly string _FILE_PATH_ADMINISTRADOR = Path.Combine(_DIRECTORY_PATH, "Administrador.txt");

        internal static void AdicionarDesenvolvedor(string nome, string email, string senha, string cpf, DateTime dataAdmissao, DateTime dataNascimento, string genero)
        {
            var desenvolvedor = new Desenvolvedor(nome: nome, email: email, senha: senha, cpf: cpf, dataAdmissao: dataAdmissao, dataNascimento: dataNascimento, genero: genero);
            _desenvolvedores.Add(desenvolvedor);
        }

        internal static void AdicionarTechLeader(string nome, string email, string senha, string cpf, DateTime dataAdmissao, DateTime dataNascimento, string genero)
        {
            var techLeader = new TechLeader(nome: nome, email: email, senha: senha, cpf: cpf, dataAdmissao: dataAdmissao, dataNascimento: dataNascimento, genero: genero);
            _techLeaders.Add(techLeader);
        }

        internal static void AdicionarAdministrador(string nome, string email, string senha, string cpf, DateTime dataAdmissao, DateTime dataNascimento, string genero)
        {
            var administrador = new Administrador(nome: nome, email: email, senha: senha, cpf: cpf, dataAdmissao: dataAdmissao, dataNascimento: dataNascimento, genero: genero);
            _administrador.Add(administrador);
        }

        internal static Usuario BuscarPorCpf(string cpf)
        {
            Desenvolvedor dev = _desenvolvedores.FirstOrDefault(d => d.Cpf == cpf);
            TechLeader tl = _techLeaders.FirstOrDefault(t => t.Cpf == cpf);

            if (dev != null)
            {
                return dev;
            }
            else if (tl != null)
            {
                return tl;
            }
            else
            {
                return null;
            }
        }

        internal static List<Usuario> LerUsuariosTxt(string _FILE_PATH, int tipoUsuario)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                if (File.Exists(_FILE_PATH))
                {
                    using (StreamReader sr = new StreamReader(_FILE_PATH))
                    {
                        while (!sr.EndOfStream)
                        {
                            string linha = sr.ReadLine();

                            Usuario usuario = null;

                            switch (tipoUsuario)
                            {
                                case 0:
                                    usuario = ConverterLinhaParaDesenvolvedor(linha);
                                    break;
                                case 1:
                                    usuario = ConverterLinhaParaTechLeader(linha);
                                    break;
                                case 2:
                                    usuario = ConverterLinhaParaAdministrador(linha);
                                    break;
                            }

                            if (usuario != null)
                            {
                                listaUsuarios.Add(usuario);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de usuário não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }

            return listaUsuarios;
        }


        internal static List<Desenvolvedor> LerDesenvolvedorTxt()
        {
            List<Usuario> usuarios = LerUsuariosTxt(_FILE_PATH_DESENVOLVEDOR, 0);

            List<Desenvolvedor> desenvolvedores = usuarios.OfType<Desenvolvedor>().ToList();

            return desenvolvedores;
        }

        internal static List<TechLeader> LerTechLeaderTxt()
        {
            List<Usuario> usuarios = LerUsuariosTxt(_FILE_PATH_TECH_LEADER, 1);

            List<TechLeader> techLeaders = usuarios.OfType<TechLeader>().ToList();

            return techLeaders;
        }

        internal static List<Administrador> LerAdministradorTxt()
        {
            List<Usuario> usuarios = LerUsuariosTxt(_FILE_PATH_ADMINISTRADOR, 2);

            List<Administrador> administradores = usuarios.OfType<Administrador>().ToList();

            return administradores;
        }

        internal static Tuple<string, string, string, string, DateTime, DateTime, string, DateTime?> ConverterLinhaParaUsuario(string linha)
        {
            string[] objetoString = linha.Split(',');

            string senha = objetoString[0];
            string nomeCompleto = objetoString[1];
            string cpf = objetoString[2];
            string email = objetoString[3];
            DateTime dataAdmissao = DateTime.Parse(objetoString[4]);
            DateTime dataNascimento = DateTime.Parse(objetoString[5]);
            string genero = objetoString[6];

            DateTime? dataDemissao = objetoString.Length > 7 ? (DateTime?)DateTime.Parse(objetoString[7]) : null;

            return new Tuple<string, string, string, string, DateTime, DateTime, string, DateTime?>(
                senha, nomeCompleto, cpf, email, dataAdmissao, dataNascimento, genero, dataDemissao);
        }

        internal static Desenvolvedor ConverterLinhaParaDesenvolvedor(string linha)
        {
            Tuple<string, string, string, string, DateTime, DateTime, string, DateTime?> usuarioInfo = ConverterLinhaParaUsuario(linha);

            return new Desenvolvedor(usuarioInfo.Item2, usuarioInfo.Item4, usuarioInfo.Item1, usuarioInfo.Item3,
                usuarioInfo.Item5, usuarioInfo.Item6, usuarioInfo.Item7, usuarioInfo.Rest);
        }

        internal static TechLeader ConverterLinhaParaTechLeader(string linha)
        {
            Tuple<string, string, string, string, DateTime, DateTime, string, DateTime?> usuarioInfo = ConverterLinhaParaUsuario(linha);

            return new TechLeader(usuarioInfo.Item2, usuarioInfo.Item4, usuarioInfo.Item1, usuarioInfo.Item3,
                usuarioInfo.Item5, usuarioInfo.Item6, usuarioInfo.Item7, usuarioInfo.Rest);
        }

        internal static Administrador ConverterLinhaParaAdministrador(string linha)
        {
            Tuple<string, string, string, string, DateTime, DateTime, string, DateTime?> usuarioInfo = ConverterLinhaParaUsuario(linha);

            return new Administrador(usuarioInfo.Item2, usuarioInfo.Item4, usuarioInfo.Item1, usuarioInfo.Item3,
                usuarioInfo.Item5, usuarioInfo.Item6, usuarioInfo.Item7, usuarioInfo.Rest);
        }

        internal static void SalvarUsuarioTxt<T>(List<T> usuarios, string _FILE_PATH)
        {
            try
            {
                List<string> linhas = new List<string>();

                if(typeof(T) == typeof(Administrador))
                {
                    foreach (Administrador adm in usuarios.OfType<Administrador>())
                    {
                        linhas.Add($"{adm.Nome};{adm.Email};{adm.Senha};{adm.Cpf};{adm.DataAdmissao};{adm.DataNascimento};{adm.Genero};{adm.DataDemissao}");
                    }
                } else if (typeof(T) == typeof(Desenvolvedor))
                {
                    foreach (Desenvolvedor dev in usuarios.OfType<Desenvolvedor>())
                    {
                        linhas.Add($"{dev.Nome};{dev.Email};{dev.Senha};{dev.Cpf};{dev.DataAdmissao};{dev.DataNascimento};{dev.Genero};{dev.DataDemissao}");
                    }
                } else if (typeof(T) == typeof(TechLeader))
                {
                    foreach (TechLeader tl in usuarios.OfType<TechLeader>())
                    {
                        linhas.Add($"{tl.Nome};{tl.Email};{tl.Senha};{tl.Cpf};{tl.DataAdmissao};{tl.DataNascimento};{tl.Genero};{tl.DataDemissao}");
                    }
                }

                File.AppendAllLines(_FILE_PATH, linhas);

                MessageBox.Show("Usuário cadastrado com sucesso!");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        internal static void SalvarDesenvolvedorTxt(List<Desenvolvedor> devs)
        {
            try
            {
                SalvarUsuarioTxt<Desenvolvedor>(devs, _FILE_PATH_DESENVOLVEDOR);
                _desenvolvedores = LerDesenvolvedorTxt();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
