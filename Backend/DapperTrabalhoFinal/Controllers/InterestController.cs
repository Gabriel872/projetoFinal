using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController
    {
        [HttpGet]
        public IEnumerable<Interest> ListInterests()
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            return connection.Query<Interest>("SELECT * FROM interests").ToList();
        }

        [HttpPost]
        public string RegisterInterests([FromBody] Interest i)
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO interests (id_category, id_user) VALUES (?Id_category, ?Id_user)", i);

            return "Interesse efetuado com sucesso!";
        }

        [HttpPut]
        public string UpdateInterests([FromBody] Interest i)
        {
            Connection c = new();
            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE interests SET id_category = ?Id_category, id_user = ?Id_user WHERE id_interests = ?Id_interests", i);

            return "Interesse alterada com sucesso!";
        }

        [HttpDelete("{id_interests}")]
        public string DeleteInterests(int id_interests)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            int count = Contabilizar(id_interests);

            if (count > 0)
            {
                connection.Execute($@"DELETE FROM interests WHERE id_interests = {id_interests}");
                return "Interesse removido com sucesso!";
            }
            else
            {
                return $"Falha na remoção do interesse {count}";
            } 
        }

        private static int Contabilizar(int id)
        {
            Connection c = new();
            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>($@"SELECT COUNT(*) FROM interests WHERE id_interests = {id}");
        }
    }
}
