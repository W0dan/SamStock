using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Beheer.Leveranciers.GetLeveranciers
{
    public class GetLeveranciersQueryExecutor : IGetLeveranciersQueryExecutor
    {
        private readonly IContext _context;

        public GetLeveranciersQueryExecutor(IContext context)
        {
            _context = context;
        }

        public GetLeveranciersResponse Execute(GetLeveranciersRequest request)
        {
            //Opmerking: als je leveranciers wil opzoeken, moet je niet querieën in de Componenten tabel ;-)
            var result = _context.Leverancier
                .Select(x => new GetLeveranciersItem
                {
                    Naam = x.Naam,
                    //Opmerking: alle velden invullen
                    Adres = x.Adres,
                    Website = x.Site
                })
                .ToList();

            return new GetLeveranciersResponse { List = result };
        }
    }
}
