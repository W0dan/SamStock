using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SAMStock.Stock.FilterStock;
using SAMStock.Utilities;

namespace SAMStock.wpf.Stock
{
	/// <summary>
	/// Interaction logic for StockItemView.xaml
	/// </summary>
	public partial class StockItemView : Window
	{
		private IDispatcher _dispatcher;

		public StockItemView(IDispatcher dispatcher, int itemid = 0)
		{
			InitializeComponent();
			_dispatcher = dispatcher;
			if (itemid > 0)
			{
				NameTextBox.Text = _dispatcher.DispatchRequest<FilterStockRequest, FilterStockResponse>(new FilterStockRequest(componentId: itemid)).Components[0].Name;
			}
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
