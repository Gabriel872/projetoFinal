namespace DapperTrabalhoFinal.Models
{
    public class Courses
    {

        private int id_course;
        private string course_name;
        private string course_subtitle;
        private int course_people_amt;
        private int course_rating;
        private string course_language;
        private string course_creation_date;
        private string course_description;
        private string course_requirements;
        private int course_time;
        private string course_link;
        private string course_audience;
        private string course_learnings;
        private string course_knowledge_level;
        private string course_message;
        private int id_author;
        private int id_categorie;
        private int id_price_course;

        public int Id_course { get => id_course; set => id_course = value; }
        public string Course_name { get => course_name; set => course_name = value; }
        public string Course_subtitle { get => course_subtitle; set => course_subtitle = value; }
        public int Course_people_amt { get => course_people_amt; set => course_people_amt = value; }
        public int Course_rating { get => course_rating; set => course_rating = value; }
        public string Course_language { get => course_language; set => course_language = value; }
        public string Course_creation_date { get => course_creation_date; set => course_creation_date = value; }
        public string Course_description { get => course_description; set => course_description = value; }
        public string Course_requirements { get => course_requirements; set => course_requirements = value; }
        public int Course_time { get => course_time; set => course_time = value; }
        public string Course_link { get => course_link; set => course_link = value; }
        public string Course_audience { get => course_audience; set => course_audience = value; }
        public string Course_learnings { get => course_learnings; set => course_learnings = value; }
        public string Course_knowledge_level { get => course_knowledge_level; set => course_knowledge_level = value; }
        public string Course_message { get => course_message; set => course_message = value; }
        public int Id_author { get => id_author; set => id_author = value; }
        public int Id_categorie { get => id_categorie; set => id_categorie = value; }
        public int Id_price_course { get => id_price_course; set => id_price_course = value; }
    }
}
