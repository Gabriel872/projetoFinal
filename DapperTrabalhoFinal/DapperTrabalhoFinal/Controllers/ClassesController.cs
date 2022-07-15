using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController
    {
        [HttpGet]

        public IEnumerable<Classes> ListClasses()
        {
            Conexao c = new Conexao();

            using var connection = c.RealizarConexao();

            return connection.Query<Classes>("SELECT * FROM classes");
        }

        [HttpPost]

        public string RegisterUsers([FromBody] Classes cl)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO classes (class_title, class_video, class_complete) VALUES (:Class_title, :Class_video, :Class_complete)", cl);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateClasses([FromBody] Classes cl)
        {
            Conexao c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE classes SET class_title = :Class_title, class_video = :Class_video, class_complete = :Class_complete WHERE id_class = :Id_class", cl);

            return "Classe alterada com sucesso!";
        }

        [HttpDelete("{id_class}")]

        public string DeleteClasses(int id_class)
        {
            Conexao c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"DELETE FROM classes WHERE id_class = " + id_class);

            return "Classe removida com sucesso!";
        }

    }
}
