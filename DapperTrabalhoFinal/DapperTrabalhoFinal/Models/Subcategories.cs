namespace DapperTrabalhoFinal.Models
{
    public class Subcategories
    {

        private int id_subcategorie;
        private string subcategorie_name;
        private int id_categorie;

        public int Id_subcategorie { get => id_subcategorie; set => id_subcategorie = value; }
        public string Subcategorie_name { get => subcategorie_name; set => subcategorie_name = value; }
        public int Id_categorie { get => id_categorie; set => id_categorie = value; }
    }
}
