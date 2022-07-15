using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController
    {

        [HttpGet]

        public IEnumerable<Subcategories> ListSubcategories()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<Subcategories>("SELECT * FROM subcategories");
        }

        [HttpPost]

        public string RegisterSubcategories([FromBody] Subcategories sb)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO subcategories (subcategorie_name, id_categorie) VALUES (:Subcategorie_name, :Id_categorie)", sb);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateSubcategories([FromBody] Subcategories sb)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE subcategories SET subcategorie_name = :Subcategorie_name, id_categorie = :Id_categorie WHERE id_subcategorie = :Id_subcategorie", sb);

            return "Subcategoria alterada com sucesso!";
        }

        [HttpDelete("{id_subcategorie}")]

        public string DeleteSubcategories(int id_subcategorie)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_subcategorie);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM subcategories WHERE id_subcategorie = " + id_subcategorie);
                return "Subcategoria removida com sucesso!";
            }
            else
            {
                return $"Falha na remoção da subcategoria {count}";
            }
        }

        private int contabilizar(int id)
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM subcategories WHERE id_subcategorie = " + id);
        }
    }
}
