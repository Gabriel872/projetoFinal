using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
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
            Connection c = new();
            MySqlConnection obj = c.RealizarConexao();

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
            Connection c = new();
            using var connection = c.RealizarConexao();

            return connection.Query<Registration>("SELECT * FROM usuarios").ToList();
        }

        [HttpPost]
        public string RegisterUsers([FromBody] Registration registration)
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            bool validEmail = IsValidEmail(registration.User_email);
            bool validPassword = IsValidPassword(registration.User_password);
            bool validName = IsValidUserName(registration.User_name);

            if (validEmail && validPassword && validName)
            {
                connection.Execute(@"
INSERT INTO usuarios 
            (user_name, 
            user_email, 
            user_password, 
            user_role) 
     VALUES (?User_name, 
            ?User_email, 
            ?User_password, 
            ?User_role)", registration);

                return "Cadastro efetuado com sucesso!";
            }
            else
            {
                return "Falha ao cadastrar";
            }
        }

        private static bool IsValidPassword(string password)
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

        private static bool IsValidUserName(string name)
        {
            bool isIntString = name.All(char.IsDigit);

            if (name.Length < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool IsValidEmail(string email)
        {
            var trimEmail = email.Trim();

            if (trimEmail.EndsWith("."))
            {
                return false;
            }

            try
            {
                var MailAddress = new System.Net.Mail.MailAddress(email);

                if (MailAddress.Address == trimEmail)
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
