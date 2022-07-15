using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace DapperTrabalhoFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UsersController
    {

        [HttpGet("Conexao")]

        public string TestarConexao()
        {
            Conexao c = new Conexao();

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

        public IEnumerable<Users> ListUsers()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<Users>("SELECT * FROM users");
        }

        [HttpPost]

        public string RegisterUsers([FromBody] Users u)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO users (user_name, user_email, user_password, user_description, user_link, user_socialmedia, user_experience) VALUES (:User_name, :User_email, :User_password, :User_description, :User_link, :User_socialmedia, :User_experience)", u);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateUsers([FromBody] Users u)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE users SET user_name = :User_name, user_email = :User_email, user_password = :User_password, user_description = :User_description, user_link = :User_link, user_socialmedia = :User_socialmedia, user_experience = :User_experience WHERE id_user = :Id_user", u);

            return "Pessoa alterada com sucesso!";
        }

        [HttpDelete("{id_user}")]

        public string DeleteUsers(int id_user)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"DELETE FROM users WHERE id_user = " + id_user);

            return "Pessoa removida com sucesso!";
        }

    }
}
