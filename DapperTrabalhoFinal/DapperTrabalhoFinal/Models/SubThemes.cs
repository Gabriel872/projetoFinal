namespace DapperTrabalhoFinal.Models
{
    public class SubThemes
    {

        private int id_sub_theme;
        private string sub_theme_name;
        private int id_subcategorie;

        public int Id_sub_theme { get => id_sub_theme; set => id_sub_theme = value; }
        public string Sub_theme_name { get => sub_theme_name; set => sub_theme_name = value; }
        public int Id_subcategorie { get => id_subcategorie; set => id_subcategorie = value; }
    }
}
