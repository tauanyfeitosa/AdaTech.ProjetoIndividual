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
        private static List<Desenvolvedor> _desenvolvedores = new List<Desenvolvedor>
        {
            new Desenvolvedor("123", "João", "12345678910", "login1"),
            new Desenvolvedor("123", "Maria", "12345678911", "login2"),
        };
        private static List<TechLeader> _techLeaders = new List<TechLeader> 
        {
            new TechLeader("123", "José", "12345678912", "login3"),
            new TechLeader("123", "Ana", "12345678913", "login4"),
        };
        private static List<Administrador> _administrador = new List<Administrador> 
        {
            new Administrador("123", "Administrador", "12345678914", "login5"),
        };

        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "Data";
        private static readonly string _FILE_PATH_DESENVOLVEDOR = Path.Combine(_DIRECTORY_PATH, "Desenvolvedor.txt");
        private static readonly string _FILE_PATH_TECH_LEADER = Path.Combine(_DIRECTORY_PATH, "TechLeader.txt");
        private static readonly string _FILE_PATH_ADMINISTRADOR = Path.Combine(_DIRECTORY_PATH, "Administrador.txt");

        static UsuarioData()
        {
            _desenvolvedores = LerDevTxt();
            _techLeaders = LerTlTxt();
            _administrador = LerAdmTxt();
        }

        internal static void IncluirUsuario(Usuario usuario)
        {
            if (usuario is Administrador)
            {
                _administrador.Add((Administrador)usuario);
            }
            else if (usuario is TechLeader)
            {
                _techLeaders.Add((TechLeader)usuario);
            }
            else if (usuario is Desenvolvedor)
            {
                _desenvolvedores.Add((Desenvolvedor)usuario);
            }
        }

        internal static void IncluirUsuario(List<Usuario> usuarios)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario is Administrador)
                {
                    _administrador.Add((Administrador)usuario);
                }
                else if (usuario is TechLeader)
                {
                    _techLeaders.Add((TechLeader)usuario);
                }
                else if (usuario is Desenvolvedor)
                {
                    _desenvolvedores.Add((Desenvolvedor)usuario);
                }
            }
        }

        internal static void RemoverUsuario(Usuario usuario)
        {
            if (usuario is Administrador)
            {
                _administrador.Remove((Administrador)usuario);
            }
            else if (usuario is TechLeader)
            {
                _techLeaders.Remove((TechLeader)usuario);
            }
            else if (usuario is Desenvolvedor)
            {
                _desenvolvedores.Remove((Desenvolvedor)usuario);
            }
        }

        internal static void RemoverUsuario(List<Usuario> usuarios)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario is Administrador)
                {
                    _administrador.Remove((Administrador)usuario);
                }
                else if (usuario is TechLeader)
                {
                    _techLeaders.Remove((TechLeader)usuario);
                }
                else if (usuario is Desenvolvedor)
                {
                    _desenvolvedores.Remove((Desenvolvedor)usuario);
                }
            }
        }

        internal static Usuario SelecionarUsuario(string cpf)
        {
            Usuario usuario = null;

            usuario = _administrador.FirstOrDefault(x => x.Cpf == cpf);
            if (usuario != null)
            {
                return usuario;
            }

            usuario = _techLeaders.FirstOrDefault(x => x.Cpf == cpf);
            if (usuario != null)
            {
                return usuario;
            }

            usuario = _desenvolvedores.FirstOrDefault(x => x.Cpf == cpf);
            if (usuario != null)
            {
                return usuario;
            }

            return usuario;
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
                            if (tipoUsuario == 0)
                            {
                                Desenvolvedor dev = ConverterLinhaParaDev(linha);
                                listaUsuarios.Add(dev);
                            }
                            else if (tipoUsuario == 1)
                            {
                                TechLeader tl = ConverterLinhaParaTl(linha);
                                listaUsuarios.Add(tl);
                            }
                            else if (tipoUsuario == 2)
                            {
                                Administrador adm = ConverterLinhaParaAdm(linha);
                                listaUsuarios.Add(adm);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaUsuarios;
        }

        internal static List<Desenvolvedor> LerDevTxt()
        {
            List<Desenvolvedor> listaDev = new List<Desenvolvedor>();

            try
            {
                if (File.Exists(_FILE_PATH_DESENVOLVEDOR))
                {
                    List<Usuario> lista = LerUsuariosTxt(_FILE_PATH_DESENVOLVEDOR, 0);
                    if (lista.OfType<Desenvolvedor>().ToList().Count > 0)
                    {
                        listaDev = lista.OfType<Desenvolvedor>().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de desenvolvedor não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaDev;
        }

        internal static List<TechLeader> LerTlTxt()
        {
            List<TechLeader> listaTl = new List<TechLeader>();

            try
            {
                if (File.Exists(_FILE_PATH_TECH_LEADER))
                {
                    List<Usuario> lista = LerUsuariosTxt(_FILE_PATH_TECH_LEADER, 1);
                    if (lista.OfType<TechLeader>().ToList().Count > 0)
                    {
                        listaTl = lista.OfType<TechLeader>().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de tech leader não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaTl;
        }

        internal static List<Administrador> LerAdmTxt()
        {
            List<Administrador> listaAdm = new List<Administrador>();

            try
            {
                if (File.Exists(_FILE_PATH_ADMINISTRADOR))
                {
                    List<Usuario> lista = LerUsuariosTxt(_FILE_PATH_ADMINISTRADOR, 2);
                    if (lista.OfType<Administrador>().ToList().Count > 0)
                    {
                        listaAdm = lista.OfType<Administrador>().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo txt de administrador não existe.");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("O arquivo não pôde ser aberto: " + e.Message);
            }
            return listaAdm;
        }

        private static Tuple<List<string>, bool> ConverterLinhaParaUsuario(string linha)
        {
            string[] objetoString = linha.Split(',');

            string senha = objetoString[0];
            string nomeCompleto = objetoString[1];
            string cpf = objetoString[2];
            string email = objetoString[3];
            if (objetoString.Length > 4)
            {
                bool ativo = bool.Parse(objetoString[4]);

                return new Tuple<List<string>, bool>(new List<string> { senha, nomeCompleto, cpf, email }, ativo);
            }

            return new Tuple<List<string>, bool>(new List<string> { senha, nomeCompleto, cpf, email }, true);
        }

        internal static Desenvolvedor ConverterLinhaParaDev(string linha)
        {
            return new Desenvolvedor(ConverterLinhaParaUsuario(linha).Item1[0],
                                    ConverterLinhaParaUsuario(linha).Item1[1],
                                        ConverterLinhaParaUsuario(linha).Item1[2],
                                            ConverterLinhaParaUsuario(linha).Item1[3],
                                                ConverterLinhaParaUsuario(linha).Item2);
        }

        internal static Administrador ConverterLinhaParaAdm(string linha)
        {
            return new Administrador(ConverterLinhaParaUsuario(linha).Item1[0],
                                        ConverterLinhaParaUsuario(linha).Item1[1],
                                            ConverterLinhaParaUsuario(linha).Item1[2],
                                                ConverterLinhaParaUsuario(linha).Item1[3],
                                                    ConverterLinhaParaUsuario(linha).Item2);
        }

        internal static TechLeader ConverterLinhaParaTl(string linha)
        {
            return new TechLeader(ConverterLinhaParaUsuario(linha).Item1[0],
                                            ConverterLinhaParaUsuario(linha).Item1[1],
                                                ConverterLinhaParaUsuario(linha).Item1[2],
                                                    ConverterLinhaParaUsuario(linha).Item1[3],
                                                        ConverterLinhaParaUsuario(linha).Item2);
        }

        internal static void SalvarUsuariosTxt<T>(List<T> usuarios, string _FILE_PATH)
        {
            try
            {
                List<string> linhas = new List<string>();
                if (typeof(T) == typeof(Desenvolvedor))
                {
                    foreach (Desenvolvedor dev in usuarios.OfType<Desenvolvedor>())
                    {
                        string linha = ConverterUsuarioParaLinha(dev);
                        linhas.Add(linha);
                    }
                }
                else if (typeof(T) == typeof(TechLeader))
                {
                    foreach (TechLeader tl in usuarios.OfType<TechLeader>())
                    {
                        string linha = ConverterUsuarioParaLinha(tl);
                        linhas.Add(linha);
                    }
                }
                else if (typeof(T) == typeof(Administrador))
                {
                    foreach (Administrador adm in usuarios.OfType<Administrador>())
                    {
                        string linha = ConverterUsuarioParaLinha(adm);
                        linhas.Add(linha);
                    }
                }

                File.AppendAllLines(_FILE_PATH, linhas);

                MessageBox.Show($"Alterações adicionadas com sucesso no arquivo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static void SalvarTechLeaderTxt(List<TechLeader> techLeaders)
        {
            try
            {
                SalvarUsuariosTxt<TechLeader>(techLeaders, _FILE_PATH_TECH_LEADER);

                _techLeaders = LerTlTxt();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static void SalvarAdministradorTxt(List<Administrador> administradores)
        {
            try
            {
                SalvarUsuariosTxt<Administrador>(administradores, _FILE_PATH_ADMINISTRADOR);

                _administrador = LerAdmTxt();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static void SalvarDesenvolvedoresTxt(List<Desenvolvedor> desenvolvedores)
        {
            try
            {
                SalvarUsuariosTxt<Desenvolvedor>(desenvolvedores, _FILE_PATH_DESENVOLVEDOR);

                _desenvolvedores.AddRange(LerDevTxt());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar as alterações no arquivo: {ex.Message}");
            }
        }

        internal static string ConverterUsuarioParaLinha(Usuario usuario)
        {
            return $"{usuario.Senha},{usuario.Nome},{usuario.Cpf},{usuario.Email},{usuario.Ativo}";
        }

    }
}

