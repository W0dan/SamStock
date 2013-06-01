﻿using System.Collections.Generic;
using SamStock.Stock.FilterStock;
using SamStock.Stock.GetStockOverzicht;
using SamStock.Stock.GetStockOverzichtRefdata;

namespace SamStock.Web.Models
{
    public class StockViewModel
    {
        public readonly decimal _totalStockValue = 0.00M;

        public StockViewModel()
        {
        }

        private StockViewModel(GetStockRefdataResponse refdata)
        {
            Leveranciers = new List<StockViewModelLeverancier>();

            foreach (var leverancier in refdata.Leveranciers)
            {
                Leveranciers.Add(new StockViewModelLeverancier(leverancier));
            }
        }

        public StockViewModel(IEnumerable<GetStockOverzichtItem> list, GetStockRefdataResponse refdata)
            : this(refdata)
        {
            List = new List<StockViewModelItem>();

            foreach (var item in list)
            {
                List.Add(new StockViewModelItem(item));
                _totalStockValue += item.Hoeveelheid*item.Prijs;
            }
        }

        public StockViewModel(IEnumerable<FilterStockItem> list, GetStockRefdataResponse refdata)
            : this(refdata)
        {
            List = new List<StockViewModelItem>();

            foreach (var item in list)
            {
                List.Add(new StockViewModelItem(item));
            }
        }

        public StockViewModel(IEnumerable<FilterStockItem> list, GetStockRefdataResponse refdata, decimal totalStockValue)
            : this(refdata) {
            List = new List<StockViewModelItem>();

            foreach (var item in list) {
                List.Add(new StockViewModelItem(item));
            }

            _totalStockValue = totalStockValue;
        }

        public List<StockViewModelItem> List { get; private set; }

        public List<StockViewModelLeverancier> Leveranciers { get; private set; }
    }
}