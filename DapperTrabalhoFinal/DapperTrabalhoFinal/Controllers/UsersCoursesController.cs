using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersCoursesController
    {
        [HttpGet]

        public IEnumerable<UsersCourses> ListUsersCourses()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<UsersCourses>("SELECT * FROM user_courses");
        }


        [HttpGet("{id_user}")]

        public IEnumerable<Courses> ListCoursesById(int id_user)
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":id_user", id_user);

            var builder = new SqlBuilder();
            builder.Where(":id_user = id_user", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT * FROM user_courses /**where**/");

            var courses = connection.Query<Courses>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();

            return courses;
        }

        [HttpPost]

        public string RegisterUsersCourses([FromBody] UsersCourses uc)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO user_courses (id_user, id_course) VALUES (:Id_user, :Id_course)", uc);

            return "Cadastro efetuado com sucesso!";
        }


        [HttpDelete("{id_user_course}")]

        public string DeleteUsersCourses(int id_user_course)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_user_course);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM user_courses WHERE id_user_course = " + id_user_course);
                return "Removido com sucesso!";
            }
            else
            {
                return $"Falha na remoção {count}";
            }
        }

        private int contabilizar(int id)
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM user_courses WHERE id_user_course = " + id);
        }
    }
}
