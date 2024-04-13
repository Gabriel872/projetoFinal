using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterCourseController
    {
        [HttpGet]
        public IEnumerable<RegisterCourse> ListCourses()
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            return connection.Query<RegisterCourse>("SELECT * FROM courses").ToList();
        }
        [HttpPost]
        public string RegisterCourse([FromBody] RegisterCourse rc)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO courses (course_name, course_subtitle, course_language, course_creation_date, 
                                    course_description, course_requirements, course_time, course_link, course_audience, course_knowledge_level, id_author, id_category, id_price_course) 
                                        VALUES (?Course_name, ?Course_subtitle, ?Course_language, ?Course_creation_date, ?Course_description, ?Course_requirements, ?Course_time, ?Course_link, 
                                            ?Course_audience, ?Course_knowledge_level, ?Id_author, ?Id_category, ?Id_price_course)", rc);

            return "Cadastro efetuado com sucesso!";
        }
    }
}
