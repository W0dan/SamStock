namespace SamStock.Supplier.GetSuppliers
{
    public class GetSuppliersItem
    {
        public GetSuppliersItem()
        {
        }

        public GetSuppliersItem(string naam, string adres, string website) {
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