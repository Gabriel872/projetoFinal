using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController
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

        public IEnumerable<Cadastro> ListUsers()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<Cadastro>("SELECT * FROM usuarios");
        }

        [HttpPost]

        public string RegisterUsersTeste([FromBody] Cadastro u)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO usuarios (user_name, user_email, user_password, user_role) VALUES (:User_name, :User_email, :User_password, :User_role)", u);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpGet("{codigo}")]
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
