namespace DapperTrabalhoFinal.Models
{
    public class SubTheme
    {

        private int id_sub_theme;
        private string sub_theme_name;
        private int id_subcategory;

        public int Id_sub_theme { get => id_sub_theme; set => id_sub_theme = value; }
        public string Sub_theme_name { get => sub_theme_name; set => sub_theme_name = value; }
        public int Id_subcategory { get => id_subcategory; set => id_subcategory = value; }
    }
}
