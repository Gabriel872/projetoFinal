using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController
    {

        [HttpGet]

        public IEnumerable<Ratings> ListRatings()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<Ratings>("SELECT * FROM ratings");
        }

        [HttpPost]

        public string RegisterRatings([FromBody] Ratings r)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO ratings (rating_text, id_user, id_course) VALUES (:Rating_text, :Id_user, :Id_course)", r);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateRatings([FromBody] Ratings r)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE ratings SET rating_text = :Rating_text, id_user = :Id_user, id_course = :Id_course WHERE id_rating = :Id_rating", r);

            return "Avaliação alterada com sucesso!";
        }

        [HttpDelete("{id_rating}")]

        public string DeleteRatings(int id_rating)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_rating);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM ratings WHERE id_rating = " + id_rating);
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

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM ratings WHERE id_rating = " + id);
        }

    }
}
