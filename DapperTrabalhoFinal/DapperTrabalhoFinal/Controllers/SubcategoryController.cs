using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoryController
    {

        [HttpGet]

        public IEnumerable<Subcategory> ListSubcategories()
        {
            Connection c = new Connection();

            using var connection = c.RealizarConexao();

            return connection.Query<Subcategory>("SELECT * FROM subcategories").ToList();
        }                                                                                                                                                                                                                                                                                   

        [HttpPost]

        public string RegisterSubcategories([FromBody] Subcategory sb)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO subcategories (subcategory_name, id_category) VALUES (:Subcategory_name, :Id_category)", sb);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateSubcategories([FromBody] Subcategory sb)
        {       
            Connection c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE subcategories SET subcategory_name = :Subcategory_name, id_category = :Id_category WHERE id_subcategory = :Id_subcategory", sb);

            return "Subcategoria alterada com sucesso!";
        }

        [HttpDelete("{id_subcategory}")]

        public string DeleteSubcategories(int id_subcategory)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_subcategory);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM subcategories WHERE id_subcategory = " + id_subcategory);
                return "Subcategoria removida com sucesso!";
            }
            else
            {
                return $"Falha na remoção da subcategoria {count}";
            }
        }

        private int contabilizar(int id)
        {
            Connection c = new Connection();

            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM subcategories WHERE id_subcategory = " + id);
        }
    }
}

