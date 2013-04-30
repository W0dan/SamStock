namespace SamStock.Beheer.Leveranciers.GetLeveranciers
{
    public class GetLeveranciersItem
    {
        //Opmerking: private constructor required if you use object initialization
        public GetLeveranciersItem()
        {
        }

        //Opmerking: public !! not private
        public GetLeveranciersItem(string naam, string adres, string website) {
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