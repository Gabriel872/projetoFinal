namespace DapperTrabalhoFinal.Models
{
    public class Rating
    {

        private int id_rating;
        private string rating_text;
        private int id_user;
        private int id_course;

        public int Id_rating { get => id_rating; set => id_rating = value; }
        public string Rating_text { get => rating_text; set => rating_text = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_course { get => id_course; set => id_course = value; }
    }
}
