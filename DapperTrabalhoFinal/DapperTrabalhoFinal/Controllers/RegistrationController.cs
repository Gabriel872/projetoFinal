using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Text.RegularExpressions;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController
    {

        [HttpGet("Connection")]

        public string TestarConexao()
        {
            Connection c = new Connection();

            OracleConnection obj = c.RealizarConexao();

            obj.Open();

            string Mensagem;

            if (obj.State.ToString() == "Open")
            {
                Mensagem = "Conexão efetuada";
            }
            else
            {
                Mensagem = "Falha ao cadastrar";
            }
            return Mensagem;
        }

        [HttpGet]

        public IEnumerable<Registration> ListUsers()
        {
            Connection c = new Connection();

            using var connection = c.RealizarConexao();

            return connection.Query<Registration>("SELECT * FROM usuarios").ToList();
        }

        [HttpPost]

        public string RegisterUsers([FromBody] Registration r)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();


            bool verificacaoEmail = IsValidEmail(r.User_email);
            bool verificacaoSenha = isValidPassword(r.User_password);
            bool verificacaoNome = isValidUserName(r.User_name);

            if (verificacaoEmail && verificacaoSenha && verificacaoNome)
            {
                connection.Execute(@"INSERT INTO usuarios (user_name, user_email, user_password, user_role) VALUES (:User_name, :User_email, :User_password, :User_role)", r);
                return "Cadastro efetuado com sucesso!";
            }
            else
            {
                return "Falha ao cadastrar";
            }
        }
        
        private bool isValidPassword(string password)
        {
            var input = password;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isValidUserName(string name)
        {
            bool isIntString = name.All(char.IsDigit);

            if (name.Length < 5)
            {
                return false;
            }
            else
            {
                return true;
            }  
        }

        private bool IsValidEmail(string email)
        {

            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);

                if (addr.Address == trimmedEmail)
                {
                    try
                    {
                        return Regex.IsMatch(email,
                            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                    }
                    catch (RegexMatchTimeoutException)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
