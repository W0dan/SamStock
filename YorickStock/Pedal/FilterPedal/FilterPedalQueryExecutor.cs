using System.Linq;
using SamStock.Database;

namespace SamStock.Pedal.FilterPedal
{
    public class FilterPedalQueryExecutor : IFilterPedalQueryExecutor
    {
        private readonly IContext _context;

        public FilterPedalQueryExecutor(IContext context)
        {
            _context = context;
        }

        public FilterPedalResponse Execute(FilterPedalRequest request)
        {
            var defaultpedalpricemargin = _context.AdminData.Single(y => y.Name == "DefaultPedalPriceMargin").Value;

            var allPedals = from p in _context.Pedal
                         select new FilterPedalResponsePedal
                             {
                                 Id = p.Id,
                                 Margin = p.Margin ?? defaultpedalpricemargin,
                                 Name = p.Name,
                                 Price = p.Price,
                                 Components = _context.PedalComponent.Where(pc => pc.PedalId == p.Id).Select(pc => new FilterPedalResponseComponent
                                     {
                                         Description = pc.Component.Name,
                                         ItemCode = pc.Component.ItemCode,
                                         Price = pc.Component.Price,
                                         Quantity = pc.Number,
                                         Stock = pc.Component.Stock,
                                         Stocknr = pc.Component.Stocknr
                                     })
                             };

            var filterPedalResponse = new FilterPedalResponse
                {
                    Pedals = request.Id > 0 ? allPedals.Where(p => p.Id == request.Id).ToList() : allPedals.ToList()
                };
            return filterPedalResponse;
        }
    }

    public class PedalComponentDelegator
    {
        public int Id;
        public int Quantity;
    }
}