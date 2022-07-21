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

        [HttpGet("{id_course}")]

        public IEnumerable<Courses> ListIdCourses(int id_course)
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<Courses>("SELECT * FROM courses WHERE id_course = " + id_course);
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
