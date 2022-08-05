using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController
    {

        [HttpGet]

        public IEnumerable<Category> ListCategories()
        {
            Connection c = new Connection();

            using var connection = c.RealizarConexao();

            return connection.Query<Category>("SELECT * FROM categories").ToList();
        }

        [HttpPost]

        public string RegisterCategories([FromBody] Category cg)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO categories (category_name) VALUES (:Category_name)", cg);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateCategories([FromBody] Category cg)
        {
            Connection c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE categories SET category_name = :Category_name WHERE id_category = :Id_category", cg);

            return "Categoria alterada com sucesso!";
        }

        [HttpDelete("{id_category}")]

        public string DeleteCategories(int id_category)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_category);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM categories WHERE id_category = " + id_category);
                return "Categoria removida com sucesso!";
            }
            else
            {
                return $"Falha na remoção da categoria {count}";
            }
        }

        private int contabilizar(int id)
        {
            Connection c = new Connection();


            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM categories WHERE id_category = " + id);
        }


        [HttpGet("validateRemoval/{id_category}")]
        public Message validateRemoval(int id_category)
        {

            // Instanciar objeto da classe Mensagem
            Message m = new Message();

            // Instanciar objeto da classe Conexão
            Connection c = new();

            // Realizar conexão com o banco de dados Oracle - DAPPER
            using var connection = c.RealizarConexao();

            // Objeto dinâmico para executar a procedure
            var obj = new DynamicParameters();
            obj.Add(":id_categ", id_category, direction: ParameterDirection.Input);
            obj.Add(":returns", "", direction: ParameterDirection.Output);

            // Executar a inserção
            connection.Query<Message>("validate_removal", obj, commandType: CommandType.StoredProcedure).ToString();

            // Retornar a mensagem e armazenar em um objeto do tipo Mensagem
            m.ReturnMessage = obj.Get<string>(":returns");

            // Retorno da API
            return m;
        }
    }
}
