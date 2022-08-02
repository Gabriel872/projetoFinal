using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        [HttpPost]

        public string RegisterCategories([FromBody] Categories cg)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO categories (category_name) VALUES (:Category_name)", cg);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateCategories([FromBody] Categories cg)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE categories SET category_name = :Category_name WHERE id_category = :Id_category", cg);

            return "Categoria alterada com sucesso!";
        }

        [HttpDelete("{id_category}")]

        public string DeleteCategories(int id_category)
        {
            Conexao c = new();

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
            Conexao c = new Conexao();


            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM categories WHERE id_category = " + id);
        }


        [HttpGet("validateRemoval/{codigo}")]
        public Mensagem Teste(int codigo)
        {

            // Instanciar objeto da classe Mensagem
            Mensagem m = new Mensagem();

            // Instanciar objeto da classe Conexão
            Conexao c = new();

            // Realizar conexão com o banco de dados Oracle - DAPPER
            using var connection = c.RealizarConexao();

            // Objeto dinâmico para executar a procedure
            var obj = new DynamicParameters();
            obj.Add(":id_categ", codigo, direction: ParameterDirection.Input);
            obj.Add(":returns", "", direction: ParameterDirection.Output);

            // Executar a inserção
            connection.Query<Mensagem>("validate_removal", obj, commandType: CommandType.StoredProcedure).ToString();

            // Retornar a mensagem e armazenar em um objeto do tipo Mensagem
            m.MensagemRetorno = obj.Get<string>(":returns");

            // Retorno da API
            return m;
        }
    }
}
