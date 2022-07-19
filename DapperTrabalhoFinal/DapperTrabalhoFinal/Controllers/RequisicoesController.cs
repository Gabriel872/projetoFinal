using Dapper;
using DapperTrabalhoFinal.Config;
using Microsoft.AspNetCore.Mvc;


namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RequisicoesController
    {
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

        [HttpGet("cursoAula")]

        public IEnumerable<RequisicoesController> ListCursoAula()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<RequisicoesController>("SELECT classes.id_course FROM classes WHERE courses.id_course = classes.id_course");
        }
       
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

            return connection.Query<RequisicoesController>("SELECT id_course FROM course_sections WHERE courses.id_course = course_sections.id_course;");
        }

    }
}
