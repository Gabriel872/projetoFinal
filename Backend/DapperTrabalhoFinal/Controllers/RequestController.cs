using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;


namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RequestController
    {
        // Comando para formatar data em DD/MM/YYYY
        [HttpGet("formatDate")]
        public IEnumerable<Course> formatDate()
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("TO_CHAR(course_creation_date, 'DD/MM/YYYY')");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ from courses");
            var dados = connection.Query<Course>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para selecionar os cursos da categoria
        [HttpGet("coursesByCategory/{id_category}")]
        public IEnumerable<Course> ListCourses(int id_category)
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":id_category", id_category);

            var builder = new SqlBuilder();
            builder.Where(":id_category = id_category", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT * FROM courses /**where**/");
            var courses = connection.Query<Course>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();
            return courses;
        }

        // Comando para criar ligacao dos desejos com cursos
        [HttpGet("wishesCourses")]
        public IEnumerable<Wish> WishesCourses()
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("wishes.id_course");
            builder.InnerJoin("courses ON courses.id_course = wishes.id_course");
            builder.InnerJoin("usuarios ON usuarios.id_user = wishes.id_user");
            builder.Where("wishes.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM wishes /**innerjoin**/ /**where**/");
            var dados = connection.Query<Wish>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para listar categorias nos interesses
        [HttpGet("interestsByCategory")]
        public IEnumerable<Interest> InterestsByCategory()
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("interests.id_category");
            builder.InnerJoin("categories ON categories.id_category = interests.id_category");
            builder.InnerJoin("usuarios ON usuarios.id_user = interests.id_user");
            builder.Where("interests.id_category = categories.id_category");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM interests /**innerjoin**/ /**where**/");
            var dados = connection.Query<Interest>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para criar ligacao com os comentarios, curso e usuario
        [HttpGet("userRating")]
        public IEnumerable<Rating> UserRating()
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("ratings.id_rating");
            builder.InnerJoin("courses ON courses.id_course = ratings.id_course");
            builder.InnerJoin("usuarios ON usuarios.id_user = ratings.id_user");
            builder.Where("ratings.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM ratings /**innerjoin**/ /**where**/");
            var dados = connection.Query<Rating>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para conectar o curso com a aula
        [HttpGet("classCourse")]
        public IEnumerable<Class>ClassCourse()
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("classes.id_course");
            builder.InnerJoin("courses ON courses.id_course = classes.id_course");
            builder.Where("classes.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM classes /**innerjoin**/ /**where**/");
            var dados = connection.Query<Class>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para conectar a subcategoria com a categoria
        [HttpGet("subcategory")]
        public IEnumerable<Subcategory> Subcategory()
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("subcategories.id_category");
            builder.InnerJoin("categories ON categories.id_category = subcategories.id_category");
            builder.Where("subcategories.id_category = categories.id_category");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM subcategories /**innerjoin**/ /**where**/");
            var dados = connection.Query<Subcategory>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para conectar o sub tema com a subcategoria
        [HttpGet("subtheme")]
        public IEnumerable<SubTheme> Subtheme()
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("sub_themes.id_subcategory");
            builder.InnerJoin("subcategories ON subcategories.id_subcategory = sub_themes.id_subcategory");
            builder.Where("sub_themes.id_subcategory = subcategories.id_subcategory");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM sub_themes /**innerjoin**/ /**where**/");
            var dados = connection.Query<SubTheme>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para conectar o curso com as seções de curso
        [HttpGet("courseSections")]
        public IEnumerable<CourseSection> CourseSections()
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("course_sections.id_course");
            builder.InnerJoin("courses ON courses.id_course = course_sections.id_course");
            builder.Where("course_sections.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM course_sections /**innerjoin**/ /**where**/");
            var dados = connection.Query<CourseSection>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para retornar dados curso, nome categoria, nome autor e preço curso
        [HttpGet("cardCourse")]
        public IEnumerable<CardCourse> CardCourse()
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("courses.*");
            builder.Select("categories.category_name, usuarios.user_name, price_courses.price_course_value, price_courses.price_course_coin");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("categories ON courses.id_category = categories.id_category");
            builder.InnerJoin("price_courses ON courses.id_price_course = price_courses.id_price_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM courses /**innerjoin**/");
            var dados = connection.Query<CardCourse>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para retornar dados curso, nome categoria, nome autor e preço curso pelo id do curso
        [HttpGet("cardCourseById/{id_course}")]
        public IEnumerable<CardCourse> CardCourseById(int id_course)
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":id_course", id_course);

            var builder = new SqlBuilder();
            builder.Select("courses.*");
            builder.Select("categories.category_name, usuarios.user_name, price_courses.price_course_value, price_courses.price_course_coin");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("categories ON courses.id_category = categories.id_category");
            builder.InnerJoin("price_courses ON courses.id_price_course = price_courses.id_price_course");
            builder.Where(":id_course = id_course", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM courses /**innerjoin**/ /**where**/");
            var dados = connection.Query<CardCourse>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();
            return dados;
        }

        // Comando para retornar curso conforme termo digitado
        [HttpGet("search/{term}")]
        public IEnumerable<CardCourse> SearchTerm(string term)
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":termo_digitado", "%" + term + "%");

            var builder = new SqlBuilder();
            builder.Select("courses.*");
            builder.Select("price_courses.price_course_value");
            builder.Select("usuarios.user_name");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("price_courses ON courses.id_price_course = price_courses.id_price_course");
            builder.Where("LOWER(courses.course_name) LIKE LOWER(:termo_digitado)", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM courses /**innerjoin**/ /**where**/");
            var dados = connection.Query<CardCourse>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();
            return dados;
        }

        [HttpGet("search/category/{term}")]
        public IEnumerable<CardCourse> SearchCategory(string term)
        {
            Connection c = new Connection();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":termo_digitado", "%" + term + "%");

            var builder = new SqlBuilder();
            builder.Select("courses.*, price_courses.price_course_value, usuarios.user_name");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("price_courses ON courses.id_price_course = price_courses.id_price_course");
            builder.InnerJoin("categories ON courses.id_category = categories.id_category");
            builder.Where("LOWER(categories.category_name) LIKE LOWER(:termo_digitado)", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM courses /**innerjoin**/ /**where**/");
            var dados = connection.Query<CardCourse>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();
            return dados;
        }
    }
}
