namespace DapperTrabalhoFinal.Models
{
    public class Users
    {

        private int id_user;
        private string user_name;
        private string user_email;
        private string user_password;
        private string user_description;
        private string user_link;
        private string user_socialmedia;
        private string user_profession;
        private double user_hours_week;
        private string user_experience;

        public int Id_user { get => id_user; set => id_user = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string User_email { get => user_email; set => user_email = value; }
        public string User_password { get => user_password; set => user_password = value; }
        public string User_description { get => user_description; set => user_description = value; }
        public string User_link { get => user_link; set => user_link = value; }
        public string User_socialmedia { get => user_socialmedia; set => user_socialmedia = value; }
        public string User_experience { get => user_experience; set => user_experience = value; }
        public string User_profession { get => user_profession; set => user_profession = value; }
        public double User_hours_week { get => user_hours_week; set => user_hours_week = value; }
    }
}
