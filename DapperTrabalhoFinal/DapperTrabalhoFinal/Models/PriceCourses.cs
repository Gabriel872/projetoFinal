namespace DapperTrabalhoFinal.Models
{
    public class PriceCourses
    {

        private int id_price_course;
        private double price_course_value;
        private string price_course_coin;
        private double price_course_discount;

        public int Id_price_course { get => id_price_course; set => id_price_course = value; }
        public double Price_course_value { get => price_course_value; set => price_course_value = value; }
        public string Price_course_coin { get => price_course_coin; set => price_course_coin = value; }
        public double Price_course_discount { get => price_course_discount; set => price_course_discount = value; }
    }
}
