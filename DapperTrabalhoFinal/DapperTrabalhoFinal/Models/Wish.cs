namespace DapperTrabalhoFinal.Models
{
    public class Wish
    {

        private int id_wish;
        private int id_user;
        private int id_course;

        public int Id_wish { get => id_wish; set => id_wish = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_course { get => id_course; set => id_course = value; }
    }
}
