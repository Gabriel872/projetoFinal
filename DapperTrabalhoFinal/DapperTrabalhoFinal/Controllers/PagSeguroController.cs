using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace DapperTrabalhoFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class PagSeguroController
    {
        [HttpGet]

        public IEnumerable<PagSeguro> ListPagseguro()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<PagSeguro>("SELECT * FROM pagseguro");

        }

        [HttpPost]

        public string RegisterPagseguro([FromBody] PagSeguro pg)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            bool verificacaoEmail = IsValidEmail(pg.Pagseguro_email);
            bool verificaCpf = VerifyCpf(pg.Pagseguro_cpf);
            bool existeEmail = emailExiste(pg.Pagseguro_email);


            if (verificacaoEmail && verificaCpf && existeEmail)
            {
                connection.Execute(@"INSERT INTO pagseguro (pagseguro_name, pagseguro_email, pagseguro_cpf) VALUES (:Pagseguro_name, :Pagseguro_email, :Pagseguro_cpf)", pg);
                return "Email e cpf cadastrado com sucesso!";
            }
            else
            {
                return "Falha no cadastro";
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

        private bool emailExiste(string email)
        {
            PagSeguro pg = new PagSeguro();

            if (email == pg.Pagseguro_email)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool VerifyCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf, digito;

            int soma, resto;

            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)

                return false;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}

