namespace DapperTrabalhoFinal.Models
{
    public class CourseSection
    {

        private int id_course_sect;
        private string course_sect_name;
        private int id_course;

        public int Id_course_sect { get => id_course_sect; set => id_course_sect = value; }
        public string Course_sect_name { get => course_sect_name; set => course_sect_name = value; }
        public int Id_course { get => id_course; set => id_course = value; }
    }
}
