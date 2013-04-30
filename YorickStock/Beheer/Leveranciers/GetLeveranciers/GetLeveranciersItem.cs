namespace SamStock.Beheer.Leveranciers.GetLeveranciers
{
    public class GetLeveranciersItem
    {
        GetLeveranciersItem(string naam, string adres, string website) {
            Naam = naam;
            Adres = adres;
            Website = website;
        }

        public string Naam
        {
            get; set;
        }

        public string Adres
        {
            get; set;
        }

        public string Website
        {
            get; set;
        }
    }
}