using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateUserController
    {
        [HttpGet]

        public IEnumerable<Cadastro> ListUsers()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<Cadastro>("SELECT * FROM usuarios");
        }

        [HttpPut]
        public string UpdateUser([FromBody] UpdateUser u)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE usuarios SET user_name = :User_name, user_email = :User_email, user_password = :User_password, user_description = :User_description WHERE id_user = :Id_user", u);

            return "Usuário alterado com sucesso!";
        }
    }
}
