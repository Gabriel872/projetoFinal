namespace DapperTrabalhoFinal.Models
{
    public class Class
    {

        private int id_class;
        private string class_title;
        private string class_video;
        private int class_complete;

        public int Id_class { get => id_class; set => id_class = value; }
        public string Class_title { get => class_title; set => class_title = value; }
        public string Class_video { get => class_video; set => class_video = value; }
        public int Class_complete { get => class_complete; set => class_complete = value; }
    }
}
