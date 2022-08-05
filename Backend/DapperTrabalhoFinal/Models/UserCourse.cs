namespace DapperTrabalhoFinal.Models
{
    public class UserCourse
    {

        private int id_user_course;
        private int id_user;
        private int id_course;

        public int Id_user_course { get => id_user_course; set => id_user_course = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_course { get => id_course; set => id_course = value; }
    }
}
