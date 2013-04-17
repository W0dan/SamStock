namespace SamStock.Beheer.Leveranciers.GetLeveranciers
{
    public class GetLeveranciersItem
    {
        private readonly string _naam;
        private readonly string _adres;
        private readonly string _website;

        public GetLeveranciersItem(string naam, string adres, string website)
        {
            _naam = naam;
            _adres = adres;
            _website = website;
        }

        public string Naam
        {
            get { return _naam; }
        }

        public string Adres
        {
            get { return _adres; }
        }

        public string Website
        {
            get { return _website; }
        }
    }
}