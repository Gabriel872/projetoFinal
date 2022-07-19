using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InterestsController
    {

        [HttpGet]

        public IEnumerable<Interests> ListInterests()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<Interests>("SELECT * FROM interests");
        }

        [HttpPost]

        public string RegisterInterests([FromBody] Interests i)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO interests (id_categorie, id_user) VALUES (:Id_categorie, :Id_user)", i);

            return "Interesse efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateInterests([FromBody] Interests i)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE interests SET id_categorie = :Id_categorie, id_user = :Id_user WHERE id_interests = :Id_interests", i);

            return "Interesse alterada com sucesso!";
        }

        [HttpDelete("{id_interests}")]

        public string DeleteInterests(int id_interests)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_interests);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM interests WHERE id_interests = " + id_interests);
                return "Interesse removido com sucesso!";
            }
            else
            {
                return $"Falha na remoção do interesse {count}";
            } 
        }

        private int contabilizar(int id)
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM interests WHERE id_interests = " + id);
        }
    }
}
