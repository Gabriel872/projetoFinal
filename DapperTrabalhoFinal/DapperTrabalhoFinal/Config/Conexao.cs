using Oracle.ManagedDataAccess.Client;

namespace DapperTrabalhoFinal.Config
{
    public class Conexao
    {
        public OracleConnection RealizarConexao()
        {
            string StringConexao = "DATA SOURCE = (DESCRIPTION ="
                + "(ADDRESS = (PROTOCOL = TCP)(HOST=192.168.15.18)(PORT=1521))"
                + "(CONNECT_DATA =(SERVER = DEDICATED)"
                + "(SERVICE_NAME = TREINAMENTO))));"
                + "User Id=aluno05;Password=aluno05;";

            // retorno contendo o acesso ao banco de dados
            return new OracleConnection(StringConexao);
        }
    }
}

