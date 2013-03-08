﻿using System.Windows.Forms;
using YorickStock.Database;
using YorickStock.GetStockOverzicht;

namespace YorickStock.Stock
{
    public class StockController
    {
        public GetStockOverzichtHandler CreateGetStockOverzichtHandler()
        {
            var context = new StockBeheerEntities();
            var queryExecutor = new GetStockOverzichtQueryExecutor(context);
            return new GetStockOverzichtHandler(queryExecutor);
        }

        public void GetStockOverzicht(ListView stockOverviewListView)
        {
            stockOverviewListView.Columns.Add("Stocknr");
            stockOverviewListView.Columns.Add("Naam", 200);
            stockOverviewListView.Columns.Add("Prijs");
            stockOverviewListView.Columns.Add("Hoeveelheid", 100);
            stockOverviewListView.Columns.Add("Minimum stock", 100);
            stockOverviewListView.Columns.Add("Leverancier", 150); 
            stockOverviewListView.Columns.Add("Opmerkingen", 200);
           

            var stockOverzicht = CreateGetStockOverzichtHandler().Handle(new GetStockOverzichtQuery());

            foreach (var item in stockOverzicht.List)
            {
                var listViewItem = new ListViewItem(item.Stocknr);

                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, item.Naam));
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, item.Prijs.ToString("0.00")));
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, item.Hoeveelheid.ToString("0")));
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, item.MinimumStock.ToString("0")));
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, item.LeverancierNaam));
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, item.Opmerkingen));

                stockOverviewListView.Items.Add(listViewItem);
            }
        }
    }
}