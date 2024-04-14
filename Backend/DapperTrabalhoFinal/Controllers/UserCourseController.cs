using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCourseController
    {
        [HttpGet]

        public IEnumerable<UserCourse> ListUsersCourses()
        {
            Connection c = new Connection();

            using var connection = c.RealizarConexao();

            return connection.Query<UserCourse>("SELECT * FROM user_courses");
        }


        [HttpGet("{id_user}")]
        public IEnumerable<CardCourse> ListCoursesById(int id_user)
        {

            Connection c = new();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new();
            Parametro.Add(":id_user", id_user);

            var builder = new SqlBuilder();
            builder.Select("categories.category_name, usuarios.user_name, price_courses.price_course_value");
            builder.InnerJoin("courses on courses.id_course = user_courses.id_course");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("categories ON courses.id_category = categories.id_category");
            builder.InnerJoin("price_courses ON courses.id_price_course = price_courses.id_price_course");
            builder.Where(":id_user = user_courses.id_user", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT courses.*, /**select**/ FROM user_courses /**innerjoin**/ /**where**/");

            var courses = connection.Query<CardCourse>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();

            return courses;
        }

        [HttpPost]
        public string RegisterUsersCourses([FromBody] UserCourse uc)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO user_courses (id_user, id_course) VALUES (:Id_user, :Id_course)", uc);

            return "Cadastro efetuado com sucesso!";
        }


        [HttpDelete("{id_user_course}")]
        public string DeleteUsersCourses(int id_user_course)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            int count = Contabilizar(id_user_course);

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

        private static int Contabilizar(int id)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM user_courses WHERE id_user_course = " + id);
        }
    }
}
