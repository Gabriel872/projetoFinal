using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace DapperTrabalhoFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PriceCoursesController
    {

            [HttpGet("Conexao")]

            public string TestarConexao()
            {
                Conexao c = new Conexao();

                OracleConnection obj = c.RealizarConexao();

                obj.Open();

                string Mensagem;

                if (obj.State.ToString() == "Open")
                {
                    Mensagem = "Conexão efetuada";
                }
                else
                {
                    Mensagem = "Falha ao cadastrar";
                }

                return Mensagem;
            }

            [HttpGet]

            public IEnumerable<PriceCourses> ListPriceCourses()
            {
                Conexao c = new Conexao();

                using var connection = c.RealizarConexao();

                return connection.Query<PriceCourses>("SELECT * FROM price_courses");
            }

            [HttpPost]

            public string RegisterPriceCourses([FromBody] PriceCourses pc)
            {
                Conexao c = new();

                using var connection = c.RealizarConexao();

                connection.Execute(@"INSERT INTO price_courses (price_course_value, price_course_coin, price_course_discount) VALUES (:Price_course_value, :Price_course_coin, :Price_course_discount)", pc);

                return "Cadastro efetuado com sucesso!";
            }

            [HttpPut]

            public string UpdatePriceCourses([FromBody] PriceCourses pc)
            {
                Conexao c = new();

                using var conncetion = c.RealizarConexao();

                conncetion.Execute(@"UPDATE price_courses SET price_course_value = :Price_course_value, price_course_coin = :Price_course_coin, price_course_discount = :Price_course_discount WHERE id_price_course = :Id_price_course", pc);

                return "Preço curso alterado com sucesso!";
            }

            [HttpDelete("{id_price_course}")]

            public string DeletePriceCourses(int id_price_course)
            {
                Conexao c = new();

                using var connection = c.RealizarConexao();

                connection.Execute(@"DELETE FROM price_courses WHERE id_price_course = " + id_price_course);

                return "Preço curso removido com sucesso!";
            }

        }
    }

