using MySql.Data.MySqlClient;

namespace DapperTrabalhoFinal.Config
{
    public class Connection
    {
        public MySqlConnection RealizarConexao()
        {
            string StringConexao = "Server=127.0.0.1;Port=3306;Database=qestudos;Uid=root;Pwd=123456;";

            return new MySqlConnection(StringConexao);
        }
    }
}

