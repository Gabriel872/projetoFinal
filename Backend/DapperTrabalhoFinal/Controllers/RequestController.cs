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
        [HttpGet("formatDate")]
        public IEnumerable<Course> FormatDate()
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            SqlBuilder builder = new();
            builder.Select("TO_CHAR(course_creation_date, 'DD/MM/YYYY')");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ from courses");
            var dados = connection.Query<Course>(builderTemplate.RawSql).ToList();
            return dados;
        }

        [HttpGet("coursesByCategory/{id_category}")]
        public IEnumerable<Course> ListCourses(int id_category)
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add("?id_category", id_category);

            var builder = new SqlBuilder();
            builder.Where("?id_category = id_category", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT * FROM courses /**where**/");
            var courses = connection.Query<Course>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();
            return courses;
        }

        [HttpGet("wishesCourses")]
        public IEnumerable<Wish> WishesCourses()
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            SqlBuilder builder = new();
            builder.Select("wishes.id_course");
            builder.InnerJoin("courses ON courses.id_course = wishes.id_course");
            builder.InnerJoin("usuarios ON usuarios.id_user = wishes.id_user");
            builder.Where("wishes.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM wishes /**innerjoin**/ /**where**/");
            var dados = connection.Query<Wish>(builderTemplate.RawSql).ToList();
            return dados;
        }

        [HttpGet("interestsByCategory")]
        public IEnumerable<Interest> InterestsByCategory()
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            SqlBuilder builder = new();
            builder.Select("interests.id_category");
            builder.InnerJoin("categories ON categories.id_category = interests.id_category");
            builder.InnerJoin("usuarios ON usuarios.id_user = interests.id_user");
            builder.Where("interests.id_category = categories.id_category");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM interests /**innerjoin**/ /**where**/");
            var dados = connection.Query<Interest>(builderTemplate.RawSql).ToList();
            return dados;
        }

        [HttpGet("userRating")]
        public IEnumerable<Rating> UserRating()
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            SqlBuilder builder = new();
            builder.Select("ratings.id_rating");
            builder.InnerJoin("courses ON courses.id_course = ratings.id_course");
            builder.InnerJoin("usuarios ON usuarios.id_user = ratings.id_user");
            builder.Where("ratings.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM ratings /**innerjoin**/ /**where**/");
            var dados = connection.Query<Rating>(builderTemplate.RawSql).ToList();
            return dados;
        }

        [HttpGet("classCourse")]
        public IEnumerable<Class>ClassCourse()
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            SqlBuilder builder = new();
            builder.Select("classes.id_course");
            builder.InnerJoin("courses ON courses.id_course = classes.id_course");
            builder.Where("classes.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM classes /**innerjoin**/ /**where**/");
            var dados = connection.Query<Class>(builderTemplate.RawSql).ToList();
            return dados;
        }

        [HttpGet("subcategory")]
        public IEnumerable<Subcategory> Subcategory()
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            SqlBuilder builder = new();
            builder.Select("subcategories.id_category");
            builder.InnerJoin("categories ON categories.id_category = subcategories.id_category");
            builder.Where("subcategories.id_category = categories.id_category");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM subcategories /**innerjoin**/ /**where**/");
            var dados = connection.Query<Subcategory>(builderTemplate.RawSql).ToList();
            return dados;
        }

        [HttpGet("subtheme")]
        public IEnumerable<SubTheme> Subtheme()
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("sub_themes.id_subcategory");
            builder.InnerJoin("subcategories ON subcategories.id_subcategory = sub_themes.id_subcategory");
            builder.Where("sub_themes.id_subcategory = subcategories.id_subcategory");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM sub_themes /**innerjoin**/ /**where**/");
            var dados = connection.Query<SubTheme>(builderTemplate.RawSql).ToList();
            return dados;
        }

        [HttpGet("courseSections")]
        public IEnumerable<CourseSection> CourseSections()
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("course_sections.id_course");
            builder.InnerJoin("courses ON courses.id_course = course_sections.id_course");
            builder.Where("course_sections.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM course_sections /**innerjoin**/ /**where**/");
            var dados = connection.Query<CourseSection>(builderTemplate.RawSql).ToList();
            return dados;
        }

        [HttpGet("cardCourse")]
        public IEnumerable<CardCourse> CardCourse()
        {
            Connection c = new();
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

        [HttpGet("cardCourseById/{id_course}")]
        public IEnumerable<CardCourse> CardCourseById(int id_course)
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new();
            Parametro.Add("?id_course", id_course);

            var builder = new SqlBuilder();
            builder.Select("courses.*");
            builder.Select("categories.category_name, usuarios.user_name, price_courses.price_course_value, price_courses.price_course_coin");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("categories ON courses.id_category = categories.id_category");
            builder.InnerJoin("price_courses ON courses.id_price_course = price_courses.id_price_course");
            builder.Where("?id_course = id_course", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM courses /**innerjoin**/ /**where**/");
            var dados = connection.Query<CardCourse>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();
            return dados;
        }

        [HttpGet("search/{term}")]
        public IEnumerable<CardCourse> SearchTerm(string term)
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add("?termo_digitado", "%" + term + "%");

            var builder = new SqlBuilder();
            builder.Select("courses.*");
            builder.Select("price_courses.price_course_value");
            builder.Select("usuarios.user_name");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("price_courses ON courses.id_price_course = price_courses.id_price_course");
            builder.Where("LOWER(courses.course_name) LIKE LOWER(?termo_digitado)", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM courses /**innerjoin**/ /**where**/");
            var dados = connection.Query<CardCourse>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();
            return dados;
        }

        [HttpGet("search/category/{term}")]
        public IEnumerable<CardCourse> SearchCategory(string term)
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add("?termo_digitado", "%" + term + "%");

            var builder = new SqlBuilder();
            builder.Select("courses.*, price_courses.price_course_value, usuarios.user_name");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("price_courses ON courses.id_price_course = price_courses.id_price_course");
            builder.InnerJoin("categories ON courses.id_category = categories.id_category");
            builder.Where("LOWER(categories.category_name) LIKE LOWER(?termo_digitado)", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM courses /**innerjoin**/ /**where**/");
            var dados = connection.Query<CardCourse>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();
            return dados;
        }
    }
}
