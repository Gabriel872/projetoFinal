using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController
    {

        [HttpGet]

        public IEnumerable<Categories> ListCategories()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<Categories>("SELECT * FROM categories").ToList();
        }

        [HttpGet("{id_categorie}")]

        public IEnumerable<Categories> ListIdCategories()
        {
            Conexao c = new();
            using var connection = c.RealizarConexao();
            
            DynamicParameters Parametro = new DynamicParameters();
            Parametro.Add(":id_categorie", "id_categorie");

            var builder = new SqlBuilder();
            builder.Where("id_categorie = :id_categorie", Parametro);

            var builderTemplate = builder.AddTemplate("SELECT * FROM categories /**where**/");

            var categories = connection.Query<Categories>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();

            return categories;
        }
        [HttpPost]

        public string RegisterCategories([FromBody] Categories cg)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO categories (categorie_name) VALUES (:Categorie_name)", cg);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateCategories([FromBody] Categories cg)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE categories SET categorie_name = :Categorie_name WHERE id_categorie = :Id_categorie", cg);

            return "Categoria alterada com sucesso!";
        }

        [HttpDelete("{id_categorie}")]

        public string DeleteCategories(int id_categorie)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_categorie);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM categories WHERE id_categorie = " + id_categorie);
                return "Categoria removida com sucesso!";
            }
            else
            {
                return $"Falha na remoção da categoria {count}";
            }
        }

        private int contabilizar(int id)
        {
            Conexao c = new Conexao();


            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM categories WHERE id_categorie = " + id);
        }
        //private int contabilizar()
        //{
        //    Conexao c = new Conexao();
        //    using var connection = c.RealizarConexao();

        //    DynamicParameters Parametro = new DynamicParameters();
        //    Parametro.Add(":id_categorie", "id_categorie");

        //    var builder = new SqlBuilder();
        //    builder.Select("id_categorie = :id_categorie", Parametro);

        //    var builderTemplate = builder.AddTemplate("SELECT COUNT(*) FROM categories /**select**/");

        //    var categories = connection.Query<Categories>(builderTemplate.RawSql, builderTemplate.Parameters).ToList();

        //    return categories;
        //}
    }
}
