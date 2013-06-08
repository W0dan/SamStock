using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SamStock.Database;

namespace SamStock.Pedal.FilterPedal {
    public class FilterPedalQueryExecutor : IFilterPedalQueryExecutor {
        private IContext _context;

        public FilterPedalQueryExecutor(IContext context)
        {
            _context = context;
        }
        public FilterPedalResponse Execute(FilterPedalRequest request)
        {
            FilterPedalResponse response = new FilterPedalResponse();
            if (request.Id > 0)
            {
                response.List.Add(_context.Pedal.Where(p => p.Id == request.Id).Select(p => new FilterPedalResponsePedal {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Margin = p.Margin
                }).First());

                List<PedalComponentDelegator> pedalcomps = _context.PedalComponent.Where(c => c.PedalId == request.Id).Select(c => new PedalComponentDelegator {
                    Id = c.ComponentId,
                    Count = c.Number
                }).ToList();

                for (int i = 0; i < pedalcomps.Count; i++) {
                    int id = pedalcomps[i].Id;
                    int count = pedalcomps[i].Count;
                    response.List[0].List.Add(_context.Component.Where(c => c.Id == id).Select(c => new FilterPedalResponseComponent {
                        Stocknr = c.Stocknr,
                        Description = c.Naam,
                        Count = count,
                        Price = c.Prijs
                    }).First());
                }
            } else
            {
                response.List.AddRange(_context.Pedal.Select(p => new FilterPedalResponsePedal {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Margin = p.Margin
                }).ToList());

                for (int pedal = 0;pedal < response.List.Count;pedal++)
                {
                    int pid = response.List[pedal].Id;
                    List<PedalComponentDelegator> pedalcomps = _context.PedalComponent.Where(c => c.PedalId == pid).Select(c => new PedalComponentDelegator {
                        Id = c.ComponentId,
                        Count = c.Number
                    }).ToList();

                    for (int i = 0; i < pedalcomps.Count; i++) {
                        int cid = pedalcomps[i].Id;
                        int count = pedalcomps[i].Count;
                        response.List[pedal].List.AddRange(_context.Component.Where(c => c.Id == cid).Select(c => new FilterPedalResponseComponent {
                            Stocknr = c.Stocknr,
                            Description = c.Naam,
                            Count = count,
                            Price = c.Prijs
                        }).ToList());
                    }
                }
            }
            return response;
        }
    }

    public class PedalComponentDelegator
    {
        public int Id { get; set;}
        public int Count {get; set;}
    }
}