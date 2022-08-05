using Dapper;
using DapperTrabalhoFinal.Config;
using DapperTrabalhoFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTrabalhoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController
    {
        [HttpGet]

        public IEnumerable<Class> ListClasses()
        {
            Connection c = new Connection();

            using var connection = c.RealizarConexao();

            return connection.Query<Class>("SELECT * FROM classes").ToList();
        }

        [HttpPost]

        public string RegisterClasses([FromBody] Class cl)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            connection.Execute(@"INSERT INTO classes (class_title, class_video, class_complete) VALUES (:Class_title, :Class_video, :Class_complete)", cl);

            return "Cadastro efetuado com sucesso!";
        }

        [HttpPut]

        public string UpdateClasses([FromBody] Class cl)
        {
            Connection c = new();

            using var conncetion = c.RealizarConexao();

            conncetion.Execute(@"UPDATE classes SET class_title = :Class_title, class_video = :Class_video, class_complete = :Class_complete WHERE id_class = :Id_class", cl);

            return "Classe alterada com sucesso!";
        }

        [HttpDelete("{id_class}")]

        public string DeleteClasses(int id_class)
        {
            Connection c = new();

            using var connection = c.RealizarConexao();

            int count = contabilizar(id_class);

            if (count > 0)
            {
                connection.Execute(@"DELETE FROM classes WHERE id_class = " + id_class);
                return "Classe removida com sucesso!";
            }
            else
            {
                return $"Falha na remoção da classe {count}";
            }
        }

        private int contabilizar(int id)
        {
            Connection c = new Connection();

            using var connection = c.RealizarConexao();

            return connection.ExecuteScalar<int>(@"SELECT COUNT(*) FROM classes WHERE id_class = " + id);
        }

    }
}
