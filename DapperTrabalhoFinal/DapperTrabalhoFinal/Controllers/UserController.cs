using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DapperTrabalhoFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController
    {

        [HttpGet]

        public IEnumerable<User> ListUsers()
        {
            Connection c = new Connection();

            using var connection = c.RealizarConexao();

            return connection.Query<User>("SELECT * FROM usuarios").ToList();
        }

        [HttpGet("{id_user}")]

        public IEnumerable<User> ListIdUsers(int id_user)
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":id_user", id_user);

            var builder = new SqlBuilder();
            builder.Where(":id_user = id_user", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT * FROM usuarios /**where**/");

            var user = connection.Query<User>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();

            return user;
        }

        [HttpGet("validateInstructor/{id_instructor}")]
        public Message ValidateInstructor(int id_instructor)
        {

            // Instanciar objeto da classe Mensagem
            Message m = new Message();

            // Instanciar objeto da classe Conexão
            Connection c = new();

            // Realizar conexão com o banco de dados Oracle - DAPPER
            using var connection = c.RealizarConexao();

            // Objeto dinâmico para executar a procedure
            var obj = new DynamicParameters();
            obj.Add(":id_instructor", id_instructor, direction: ParameterDirection.Input);
            obj.Add(":returns", "", direction: ParameterDirection.Output);

            // Executar a inserção
            connection.Query<Message>("validate_instructor", obj, commandType: CommandType.StoredProcedure).ToString();

            // Retornar a mensagem e armazenar em um objeto do tipo Mensagem
            m.ReturnMessage = obj.Get<string>(":returns");

            // Retorno da API
            return m;
        }

        [HttpPost]

        public string RegisterUsersTeste([FromBody] User u)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            bool existeEmail = emailExiste(u.User_email);

            if (existeEmail == true)
            {
                connection.Execute(@"INSERT INTO usuarios (user_name, user_email, user_password, user_role) VALUES (:User_name, :User_email, :User_password, :User_role)", u);

                return "Cadastro efetuado com sucesso!";
            }
            else
            {
                return "Falha no cadastro";
            }

        }
        private bool emailExiste(string email)
        {
            Registration cd = new Registration();

            if (email == cd.User_email)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [HttpPut]

        public string UpdateUsers([FromBody] User u)
        {
            Connection c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE usuarios SET user_name = :User_name, user_email = :User_email, user_password = :User_password, user_description = :User_description, user_link = :User_link, user_socialmedia = :User_socialmedia, user_profession = :User_profession, user_hours_week = :User_hours_week, user_experience = :User_experience, user_role = :User_Role WHERE id_user = :Id_user", u);

            return "Pessoa alterada com sucesso!";
        }

        [HttpPut("profile")]

        public string UpdateUsersPerfil([FromBody] User u)
        {
            Connection c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE usuarios SET user_name = :User_name, user_email = :User_email, user_password = :User_password, user_description = :User_description WHERE id_user = :Id_user", u);

            return "Pessoa alterada com sucesso!";
        }

        [HttpDelete("{id_user}")]

        public string DeleteUsers(int id_user)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_user);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM usuarios WHERE id_user = " + id_user);
                return "Removido com sucesso!";
            }
            else
            {
                return $"Falha na remoção {count}";
            }
        }

        private int contabilizar(int id)
        {
            Connection c = new Connection();

            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM usuarios WHERE id_user = " + id);
        }

    }
}
