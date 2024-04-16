using Oracle.ManagedDataAccess.Client;

namespace DapperTrabalhoFinal.Config
{
    public class Connection
    {
        public OracleConnection RealizarConexao()
        {
            string StringConexao = "DATA SOURCE = (DESCRIPTION ="
                + "(ADDRESS = (PROTOCOL = TCP)(HOST=127.0.0.1)(PORT=3036))"
                + "(CONNECT_DATA =(SERVER = DEDICATED)"
                + "(SERVICE_NAME = TESTE))));"
                + "User Id=teste;Password=teste;";

            return new OracleConnection(StringConexao);
        }
    }
}

