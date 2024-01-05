using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.DataBusiness;
using AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Business.ProjetosBusiness;


namespace AdaTech.ProjetoIndividual.GerenciadorTarefas.Models.Usuarios.DataUser
{
    internal static class UsuarioData
    {
        private static List<Desenvolvedor> _desenvolvedores = new List<Desenvolvedor>();
        private static List<TechLeader> _techLeaders = new List<TechLeader>();
        private static List<Administrador> _administrador = new List<Administrador>();

        private static readonly string _DIRECTORY_PATH = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "") + "Data";
        private static readonly string _FILE_PATH_DESENVOLVEDOR = Path.Combine(_DIRECTORY_PATH, "Desenvolvedor.txt");
        private static readonly string _FILE_PATH_TECH_LEADER = Path.Combine(_DIRECTORY_PATH, "TechLeader.txt");
        private static readonly string _FILE_PATH_ADMINISTRADOR = Path.Combine(_DIRECTORY_PATH, "Administrador.txt");

        public static List<Desenvolvedor> Desenvolvedores { get => _desenvolvedores; set => _desenvolvedores = value; }
        public static List<TechLeader> TechLeaders { get => _techLeaders; set => _techLeaders = value; }
        public static List<Administrador> Administrador { get => _administrador; set => _administrador = value; }

        internal static void CarregarDados()
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

        internal static TechLeader SelecionarTechLeader (string cpf)
        {
            TechLeader techLeader = null;

            techLeader = _techLeaders.FirstOrDefault(x => x.Cpf == cpf);
            if (techLeader != null)
            {
                return techLeader;
            }

            return techLeader;
        }

        internal static bool VerificarUsuarioExistenteCpf(string cpf)
        {
            Usuario usuario = SelecionarUsuario(cpf);

            if (usuario != null)
            {
                return true;
            }

            return false;
        }

        internal static bool VerificarUsuarioExistenteEmail(string email)
        {
            Usuario usuario = SelecionarUsuario(email);

            if (usuario != null)
            {
                return true;
            }

            return false;
        }

        internal static Tuple<List<Desenvolvedor>, List<TechLeader>> ListarUsuarios(Projetos projeto)
        {
            List<Desenvolvedor> desenvolvedores = _desenvolvedores.Where(x => x.Projeto.NomeProjeto == projeto.NomeProjeto).ToList();
            List<TechLeader> techLeaders = _techLeaders.Where(x => x.Projeto.NomeProjeto == projeto.NomeProjeto).ToList();

            return new Tuple<List<Desenvolvedor>, List<TechLeader>>(desenvolvedores, techLeaders);
        }

        internal static Tuple<List<Desenvolvedor>, List<TechLeader>> ListarUsuariosAtivos(Projetos projeto)
        {
            List<Desenvolvedor> desenvolvedores = _desenvolvedores.Where(x => x.Projeto.NomeProjeto == projeto.NomeProjeto && x.Ativo == true).ToList();
            List<TechLeader> techLeaders = _techLeaders.Where(x => x.Projeto.NomeProjeto == projeto.NomeProjeto && x.Ativo == true).ToList();

            return new Tuple<List<Desenvolvedor>, List<TechLeader>>(desenvolvedores, techLeaders);
        }

        internal static void AdicionarTechLeader (string senha, string nome, string cpf, string email, Projetos projeto, bool ativo = true)
        {
            TechLeader techLeader = new TechLeader(senha, nome, cpf, email, projeto.NomeProjeto, ativo);
            _techLeaders.Add(techLeader);

            List<TechLeader> list = new List<TechLeader>();
            list.Add(techLeader);
            SalvarTechLeaderTxt(list);
        }

        internal static void AdicionarDesenvolvedor(string senha, string nome, string cpf, string email, Projetos projeto, bool ativo = true)
        {
            Desenvolvedor desenvolvedor = new Desenvolvedor(senha, nome, cpf, email, projeto.NomeProjeto, ativo);
            _desenvolvedores.Add(desenvolvedor);

            List<Desenvolvedor> list = new List<Desenvolvedor>();
            list.Add(desenvolvedor);
            SalvarDesenvolvedoresTxt(list);
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
            string projeto = objetoString[4];
            if (objetoString.Length > 5)
            {
                bool ativo = bool.Parse(objetoString[5]);

                return new Tuple<List<string>, bool>(new List<string> { senha, nomeCompleto, cpf, email, projeto }, ativo);
            }

            return new Tuple<List<string>, bool>(new List<string> { senha, nomeCompleto, cpf, email, projeto }, true);
        }

        internal static Desenvolvedor ConverterLinhaParaDev(string linha)
        {
            return new Desenvolvedor(ConverterLinhaParaUsuario(linha).Item1[0],
                                    ConverterLinhaParaUsuario(linha).Item1[1],
                                        ConverterLinhaParaUsuario(linha).Item1[2],
                                            ConverterLinhaParaUsuario(linha).Item1[3],
                                                ConverterLinhaParaUsuario(linha).Item1[4],
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
                                                        ConverterLinhaParaUsuario(linha).Item1[4],
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
            if (usuario is TechLeader|| usuario is Desenvolvedor)
            {
                return $"{usuario.Senha},{usuario.Nome},{usuario.Cpf},{usuario.Email},{(usuario as TechLeader)?.Projeto.NomeProjeto ?? (usuario as Desenvolvedor)?.Projeto.NomeProjeto},{usuario.Ativo}";
            }
            return $"{usuario.Senha},{usuario.Nome},{usuario.Cpf},{usuario.Email},{usuario.Ativo}";
        }

        internal static bool VerificarSenhaAntiga(Usuario usuario, string senha)
        {
            if (usuario.Senha == senha)
            {
                return true;
            }
            return false;
        }

        internal static void AtualizarSenha(Usuario usuario, string novaSenha)
        {
            // Atualizar a senha no objeto de usuário
            usuario.Senha = novaSenha;

            // Chamar o método para atualizar a senha no arquivo de texto
            AtualizarSenhaNoArquivo(usuario, novaSenha);
        }

        private static void AtualizarSenhaNoArquivo(Usuario usuario, string novaSenha)
        {
            try
            {
                string[] linhas = File.ReadAllLines(GetArquivoUsuario(usuario));

                for (int i = 0; i < linhas.Length; i++)
                {
                    string[] partes = linhas[i].Split(',');

                    if (partes.Length >= 4 && partes[2] == usuario.Cpf && partes[3] == usuario.Email)
                    {
                        partes[0] = novaSenha;

                        linhas[i] = string.Join(",", partes);

                        break;
                    }
                }

                File.WriteAllLines(GetArquivoUsuario(usuario), linhas);

                MessageBox.Show("Senha atualizada com sucesso no arquivo.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar a senha no arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string GetArquivoUsuario(Usuario usuario)
        {
            if (usuario is Desenvolvedor)
            {
                return _FILE_PATH_DESENVOLVEDOR;
            }
            else if (usuario is TechLeader)
            {
                return _FILE_PATH_TECH_LEADER;
            }
            else if (usuario is Administrador)
            {
                return _FILE_PATH_ADMINISTRADOR;
            }

            throw new ArgumentException("Tipo de usuário não reconhecido.");
        }


    }
}

