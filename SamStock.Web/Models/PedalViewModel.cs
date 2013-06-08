using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SamStock.Pedal.FilterPedal;

namespace SamStock.Web.Models {
    public class PedalViewModel {
        public List<PedalViewModelPedal> List { get; private set; }

        public PedalViewModel(List<FilterPedalResponsePedal> list)
        {
            List = new List<PedalViewModelPedal>();
            foreach (FilterPedalResponsePedal item in list)
            {
                List.Add(new PedalViewModelPedal(item));
            }
        }

        public PedalViewModel(FilterPedalResponsePedal p)
        {
            List = new List<PedalViewModelPedal>();
            List.Add(new PedalViewModelPedal(p));
        }
    }
}