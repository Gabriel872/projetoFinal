namespace DapperTrabalhoFinal.Models
{
    public class UpdateUser
    {
        private int id_user;
        private string user_name;
        private string user_email;
        private string user_password;
        private string user_description;

        public int Id_user { get => id_user; set => id_user = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string User_email { get => user_email; set => user_email = value; }
        public string User_password { get => user_password; set => user_password = value; }
        public string User_description { get => user_description; set => user_description = value; }
    }
}
