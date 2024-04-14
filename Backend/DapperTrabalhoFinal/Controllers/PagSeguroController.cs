using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagseguroController
    {
        [HttpGet]
        public IEnumerable<Pagseguro> ListPagseguro()
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            return connection.Query<Pagseguro>("SELECT * FROM pagseguro").ToList();
        }

        [HttpPost]
        public string RegisterPagseguro([FromBody] Pagseguro pg)
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            bool verificacaoEmail = IsValidEmail(pg.Pagseguro_email);
            bool verificaCpf = VerifyCpf(pg.Pagseguro_cpf);

            if (verificacaoEmail && verificaCpf)
            {
                connection.Execute(@"
INSERT INTO pagseguro (pagseguro_name, pagseguro_email, pagseguro_cpf) 
VALUES (?Pagseguro_name, ?Pagseguro_email, ?Pagseguro_cpf)", pg);
                return "Email e cpf cadastrado com sucesso!";
            }
            else
            {
                return "Falha no cadastro";
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
                var mailAddress = new System.Net.Mail.MailAddress(email);

                if (mailAddress.Address == trimEmail)
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

        private static bool VerifyCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf, digit;
            int sum, resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }

            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            resto = sum % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digit = resto.ToString();
            tempCpf += digit;

            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = sum % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digit += resto.ToString();

            return cpf.EndsWith(digit);
        }
    }
}

