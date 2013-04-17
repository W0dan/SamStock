using System.Collections;
using System.Collections.Generic;
using SamStock.Beheer.Leveranciers.GetLeveranciers;
using System.Linq;

namespace SamStock.Web.Models
{
    public class LeveranciersViewModel
    {
        public LeveranciersViewModel(GetLeveranciersResponse getLeveranciersResponse)
        {
            List = getLeveranciersResponse.List
                .Select(x => new BeheerViewModelLeverancier {Adres = x.Adres, Naam = x.Naam, Website = x.Website}).ToList();
        }

        public List<BeheerViewModelLeverancier> List { get; set; }

        public LeveranciersViewModelNewItem NewItem { get; set; }
    }

    public class LeveranciersViewModelNewItem
    {
        public string Naam { get; set; }

        public string Adres { get; set; }

        public string Site { get; set; }
    }

    public class BeheerViewModelLeverancier
    {
        public string Naam { get; set; }

        public string Adres { get; set; }

        public string Website { get; set; }
    }
}