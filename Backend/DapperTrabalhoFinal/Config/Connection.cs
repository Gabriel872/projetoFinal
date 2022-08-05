using Oracle.ManagedDataAccess.Client;

namespace DapperTrabalhoFinal.Config
{
    public class Connection
    {
        public OracleConnection RealizarConexao()
        {
            string StringConexao = "DATA SOURCE = (DESCRIPTION ="
                + "(ADDRESS = (PROTOCOL = TCP)(HOST=192.168.15.18)(PORT=1521))"
                + "(CONNECT_DATA =(SERVER = DEDICATED)"
                + "(SERVICE_NAME = TREINAMENTO))));"
                + "User Id=aluno04;Password=aluno04;";

            // retorno contendo o acesso ao banco de dados
            return new OracleConnection(StringConexao);
        }
    }
}

