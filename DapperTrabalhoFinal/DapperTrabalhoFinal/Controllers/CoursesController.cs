using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;


namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController
    {
        [HttpGet]

        public IEnumerable<Courses> ListCourses()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<Courses>("SELECT * FROM courses");
        }

        [HttpGet("{id_course")]

        public IEnumerable<Courses> ListCourses()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":id_course", "id_course");

            var builder = new SqlBuilder();
            builder.Where("id_course = :id_course", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT * FROM courses /**where**/");

            var courses = connection.Query<Courses>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();

            return courses;
        }

        [HttpGet("{id_categorie")]

        public IEnumerable<Courses> ListIdCategories()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":id_categorie", "id_categorie");

            var builder = new SqlBuilder();
            builder.Where("id_categorie = :id_categorie", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT * FROM courses /**where**/");

            var courses = connection.Query<Courses>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();

            return courses;
        }


        [HttpGet("formatarData")]

        public IEnumerable<RequisicoesController> FormatarData()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT TO_DATE(TO_CHAR(course_creation_date, 'DD/MM/YYYY'), 'DD/MM/YYYY') AS format_date FROM courses");
        }

        [HttpGet("cursoCategoria")]

        public IEnumerable<RequisicoesController> CursoCategoria()
        {
            Categories ct = new Categories();

            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT courses.id_categorie FROM courses INNER JOIN categories ON categories.id_categorie = courses.id_categorie WHERE courses.id_categorie = " + ct.Id_categorie);
        }

        [HttpPost]

        public string RegisterCourses([FromBody] Courses cs)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO courses (course_name, course_subtitle, course_people_amt, course_rating, course_language, course_creation_date, course_description, course_requirements, course_time, course_link, course_audience, course_learnings, course_knowledge_level, course_message, id_author, id_categorie, id_price_course)  VALUES (:Course_name, :Course_subtitle, :Course_people_amt, :Course_rating, :Course_language, :Course_creation_date, :Course_description, :Course_requirements, :Course_time, :Course_link, :Course_audience, :Course_learnings, :Course_knowledge_level, :Course_message, :Id_author, :Id_categorie, :Id_price_course)", cs);

            return "Cadastro efetuado com sucesso!";
        }

       
        [HttpPut]

        public string UpdateCourses([FromBody] Courses cs)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE courses SET course_name = :Course_name, course_subtitle = :Course_subtitle, course_people_amt = :Course_people_amt, course_rating = :Course_rating, course_language = :Course_language, course_creation_date = :Course_creation_date, course_description = :Course_description, course_requirements = :Course_requirements, course_time = :Course_time, course_link = :Course_link, course_audience = :Course_audience, course_learnings = :Course_learnings, course_knowledge_level = :Course_knowledge_level, course_message = :Course_message WHERE id_course = :Id_course", cs);

            return "Curso alterado com sucesso!";
        }

        [HttpDelete("{id_course}")]

        public string DeleteCourses(int id_course)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_course);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM courses WHERE id_course = " + id_course);
                return "Curso removido com sucesso!";
            }
            else
            {
                return $"Falha na remoção do curso {count}";
            }
        }

        private int contabilizar(int id)
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM courses WHERE id_course = " + id);
        }
    }
}
