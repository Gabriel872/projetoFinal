using Dapper;
using DapperTrabalhoFinal.Config;
using Microsoft.AspNetCore.Mvc;


namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RequisicoesController
    {
        //[HttpGet("courseValue")]
        //public IEnumerable<Object> ListCourseValue()
        //{
        //    Conexao c = new Conexao();
        //    using var connection = c.RealizarConexao();

        //    DynamicParameters Parametro = new DynamicParameters();
        //    Parametro.Add(":id_course", "id_course");

        //    var builder = new SqlBuilder();
        //    builder.InnerJoin("price_courses ON price_courses.id_price_course = courses.id_price_course");
        //    builder.Where("price_courses.id_course = :courses.id_course", Parametro);

        //    var builderTemplate = builder.AddTemplate("SELECT * FROM courses /**innerjoin**/ /**where**/");

        //    var dados = connection.Query<Object>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();

        //    return dados;
        //}

        /*SELECT* FROM courses INNER JOIN price_courses ON price_courses.id_price_course = courses.id_price_course WHERE price_courses.id_course = courses.id_course;*/


        [HttpGet("cursosCategoria")]

        public IEnumerable<RequisicoesController> ListCursoCategoria()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT id_courses FROM courses WHERE categories.id_categorie = courses.id_categorie");
        }

        [HttpGet("ligacaoUsuario")]

        public IEnumerable<RequisicoesController> Ligacao()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT * FROM courses WHERE courses.id_course = classes.id_course AND courses.id_price_course = price_courses.id_price_course AND courses.id_author = usuarios.id_user");
        }

        [HttpGet("ligacaoDesejoCurso")]

        public IEnumerable<RequisicoesController> ListDesejoCurso()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT id_course FROM wishes WHERE courses.id_course = wishes.id_course");
        }

        [HttpGet("categoriasInteresses")]

        public IEnumerable<RequisicoesController> ListCategoriasInteresses()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT id_categorie FROM interests WHERE interests.id_categorie = categories.id_categorie");
        }

        [HttpGet("comentarioUsuario")]

        public IEnumerable<RequisicoesController> Listccu()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT id_rating FROM ratings WHERE courses.id_course = ratings.id_course");
        }

/*        [HttpGet("cursoAula")]

        public IEnumerable<RequisicoesController> ListCursoAula()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT classes.id_course FROM classes WHERE courses.id_course = classes.id_course");
        }*/
       
        [HttpGet("subcategoria")]

        public IEnumerable<RequisicoesController> ListSub()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT id_categorie FROM subcategories WHERE categories.id_categorie = subcategories.id_categorie");
        }


        [HttpGet("subtema")]

        public IEnumerable<RequisicoesController> ListSubtema()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT id_subcategorie FROM sub_themes WHERE subcategories.id_subcategorie = sub_themes.id_subcategorie");
        }


        [HttpGet("secoesCurso")]

        public IEnumerable<RequisicoesController> ListSecoesCurso()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT id_course FROM course_sections WHERE courses.id_course = course_sections.id_course");
        }

        [HttpGet("cardCourse")]

        public IEnumerable<Object> cardCourse()
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
    }
}
