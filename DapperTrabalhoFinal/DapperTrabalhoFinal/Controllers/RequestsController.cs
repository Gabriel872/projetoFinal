using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;


namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RequestsController
    {
        // Comando para formatar data em DD/MM/YYYY
        [HttpGet("formatDate")]
        public IEnumerable<Object> formatDate()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("TO_CHAR(course_creation_date, 'DD/MM/YYYY') AS format_date");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ from courses");
            var dados = connection.Query<Object>(builderTemplate.RawSql).ToList();

            return dados;
        }

        // Comando para selecionar os cursos da categoria
        [HttpGet("coursesByCategorie/{id_categorie}")]
        public IEnumerable<Courses> ListCourses(int id_categorie)
        {
            Conexao c = new();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":id_categorie", id_categorie);

            var builder = new SqlBuilder();
            builder.Where(":id_categorie = id_categorie", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT * FROM courses /**where**/");

            var courses = connection.Query<Courses>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();

            return courses;
        }

        // Comando para criar ligacao dos desejos com cursos
        [HttpGet("wishesCourses")]
        public IEnumerable<Object> WishesCourses()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("wishes.id_course");
            builder.InnerJoin("courses ON courses.id_course = wishes.id_course");
            builder.InnerJoin("usuarios ON usuarios.id_user = wishes.id_user");
            builder.Where("wishes.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM wishes /**innerjoin**/ /**where**/");
            var dados = connection.Query<Object>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para listar categorias nos interesses
        [HttpGet("interestsByCategorie")]
        public IEnumerable<Object> InterestsByCategorie()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("interests.id_categorie");
            builder.InnerJoin("categories ON categories.id_categorie = interests.id_categorie");
            builder.InnerJoin("usuarios ON usuarios.id_user = interests.id_user");
            builder.Where("interests.id_categorie = categories.id_categorie");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM interests /**innerjoin**/ /**where**/");
            var dados = connection.Query<Object>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para criar ligacao com os comentarios, curso e usuario
        [HttpGet("userRating")]
        public IEnumerable<Object> UserRating()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("ratings.id_rating");
            builder.InnerJoin("courses ON courses.id_course = ratings.id_course");
            builder.InnerJoin("usuarios ON usuarios.id_user = ratings.id_user");
            builder.Where("ratings.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM ratings /**innerjoin**/ /**where**/");
            var dados = connection.Query<Object>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para conectar o curso com a aula
        [HttpGet("classCourse")]
        public IEnumerable<Object> ClassCourse()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("classes.id_course");
            builder.InnerJoin("courses ON courses.id_course = classes.id_course");
            builder.Where("classes.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM classes /**innerjoin**/ /**where**/");
            var dados = connection.Query<Object>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para conectar a subcategoria com a categoria
        [HttpGet("subcategorie")]
        public IEnumerable<Object> Subcategorie()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("subcategories.id_categorie");
            builder.InnerJoin("categories ON categories.id_categorie = subcategories.id_categorie");
            builder.Where("subcategories.id_categorie = categories.id_categorie");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM subcategories /**innerjoin**/ /**where**/");
            var dados = connection.Query<Object>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para conectar o sub tema com a subcategoria
        [HttpGet("subtheme")]
        public IEnumerable<Object> Subtheme()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("sub_themes.id_subcategorie");
            builder.InnerJoin("subcategories ON subcategories.id_subcategorie = sub_themes.id_subcategorie");
            builder.Where("sub_themes.id_subcategorie = subcategories.id_subcategorie");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM sub_themes /**innerjoin**/ /**where**/");
            var dados = connection.Query<Object>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para conectar o curso com as seções de curso
        [HttpGet("courseSections")]
        public IEnumerable<Object> CourseSections()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("course_sections.id_course");
            builder.InnerJoin("courses ON courses.id_course = course_sections.id_course");
            builder.Where("course_sections.id_course = courses.id_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM course_sections /**innerjoin**/ /**where**/");
            var dados = connection.Query<Object>(builderTemplate.RawSql).ToList();
            return dados;
        }


        [HttpGet("cardCourse")]
        public IEnumerable<Object> CardCourse()
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            var builder = new SqlBuilder();
            builder.Select("courses.*");
            builder.Select("categories.categorie_name, usuarios.user_name, price_courses.price_course_value, price_courses.price_course_coin");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("categories ON courses.id_categorie = categories.id_categorie");
            builder.InnerJoin("price_courses ON courses.id_price_course = price_courses.id_price_course");

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM courses /**innerjoin**/");
            var dados = connection.Query<Object>(builderTemplate.RawSql).ToList();
            return dados;
        }

        // Comando para retornar dados curso, nome categoria, nome autor e preço curso
        [HttpGet("cardCourseById/{id_course}")]
        public IEnumerable<Object> CardCourseById(int id_course)
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":id_course", id_course);

            var builder = new SqlBuilder();
            builder.Select("courses.*");
            builder.Select("categories.categorie_name, usuarios.user_name, price_courses.price_course_value, price_courses.price_course_coin");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("categories ON courses.id_categorie = categories.id_categorie");
            builder.InnerJoin("price_courses ON courses.id_price_course = price_courses.id_price_course");
            builder.Where(":id_course = id_course", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM courses /**innerjoin**/ /**where**/");
            var dados = connection.Query<Object>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();
            return dados;
        }

        // Comando para retornar curso conforme termo digitado
        [HttpGet("searchTerm")]
        public IEnumerable<Object> SearchTerm(string termo)
        {
            Conexao c = new Conexao();
            using var connection = c.RealizarConexao();

            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":termo_digitado", termo);

            var builder = new SqlBuilder();
            builder.Select("courses.id_course");
            builder.InnerJoin("usuarios ON courses.id_author = usuarios.id_user");
            builder.InnerJoin("categories ON courses.id_categorie = categories.id_categorie");
            builder.Where("courses.course_name LIKE '%termo_digitado%' OR '%termo_digitado%' = usuarios.user_name OR '%termo_digitado%' = categories.categorie_name", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM courses /**innerjoin**/ /**where**/");
            var dados = connection.Query<Object>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();
            return dados;
        }
    }
}
