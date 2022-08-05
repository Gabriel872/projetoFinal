namespace DapperTrabalhoFinal.Models
{
    public class Subcategory
    {

        private int id_subcategory;
        private string subcategory_name;
        private int id_category;

        public int Id_subcategory { get => id_subcategory; set => id_subcategory = value; }
        public string Subcategory_name { get => subcategory_name; set => subcategory_name = value; }
        public int Id_category { get => id_category; set => id_category = value; }
    }
}
