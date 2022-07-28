using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PriceCoursesController
    {

        [HttpGet]

        public IEnumerable<PriceCourses> ListPriceCourses()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<PriceCourses>("SELECT * FROM price_courses");
        }

        [HttpGet("{id_price_course}")]

        public IEnumerable<PriceCourses> ListPriceCoursesById(int id_price_course)
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<PriceCourses>("SELECT * FROM price_courses WHERE id_price_course =" + id_price_course);
        }

        [HttpPost]

        public string RegisterPriceCourses([FromBody] PriceCourses pc)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO price_courses (price_course_value, price_course_coin, price_discount) VALUES (:Price_course_value, :Price_course_coin, :Price_discount)", pc);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdatePriceCourses([FromBody] PriceCourses pc)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE price_courses SET price_course_value = :Price_course_value, price_course_coin = :Price_course_coin, price_discount = :Price_discount WHERE id_price_course = :Id_price_course", pc);

            return "Preço curso alterado com sucesso!";
        }

        [HttpDelete("{id_price_course}")]

        public string DeletePriceCourses(int id_price_course)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_price_course);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM price_courses WHERE id_price_course = " + id_price_course);
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

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM price_courses WHERE id_price_course = " + id);
        }

    }
}

