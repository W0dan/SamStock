using System;
using System.Collections.Generic;
using System.Globalization;
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
using SAMStock.DTO.Component.AddComponent;
using SAMStock.DTO.Component.FilterComponent;
using SAMStock.DTO.Component.UpdateComponent;
using SAMStock.DTO.Supplier.FilterSuppliers;
using SAMStock.Utilities;
using SAMStock.wpf.Castle;

namespace SAMStock.wpf.Dialogs
{
	/// <summary>
	/// Interaction logic for ComponentViewWindow.xaml
	/// </summary>
	public partial class ComponentViewWindow : Window
	{
		private readonly bool _editMode = false;
		private readonly IDispatcher _dispatcher = WindsorContainerStore.Container.Resolve<IDispatcher>();
		private readonly FilterComponentResponseItem _comp;
		public List<FilterSuppliersResponseItem> Suppliers { get; private set; }

		public ComponentViewWindow()
		{
			InitializeComponent();
			SupplierComboBox.ItemsSource =
				_dispatcher.DispatchRequest<FilterSuppliersRequest, FilterSuppliersResponse>(new FilterSuppliersRequest())
					.Suppliers;
		}

		public ComponentViewWindow(FilterComponentResponseItem comp)
		{
			InitializeComponent();
			SupplierComboBox.ItemsSource =
				_dispatcher.DispatchRequest<FilterSuppliersRequest, FilterSuppliersResponse>(new FilterSuppliersRequest())
					.Suppliers;
			_editMode = true;
			_comp = comp;

			StocknrTextBox.Text = _comp.Stocknr;
			NameTextBox.Text = _comp.Name;
			PriceTextBox.Text = _comp.Price.ToString(CultureInfo.InvariantCulture);
			MinimumStockTextBox.Text = _comp.MinimumStock.ToString(CultureInfo.InvariantCulture);
			QuantityTextBox.Text = _comp.Quantity.ToString(CultureInfo.InvariantCulture);
			RemarkTextBox.Text = _comp.Remark;
			ItemCodeTextBox.Text = _comp.ItemCode;
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			decimal price;
			int minimumstock, quantity;
			decimal.TryParse(PriceTextBox.Text, out price);
			int.TryParse(MinimumStockTextBox.Text, out minimumstock);
			int.TryParse(QuantityTextBox.Text, out quantity);
			if (_editMode)
			{
				_dispatcher.DispatchCommand<UpdateComponentCommand>(new UpdateComponentCommand
				{
					Id = _comp.Id,
					Stocknr = StocknrTextBox.Text,
					Name = NameTextBox.Text,
					Price = price,
					MinimumStock = minimumstock,
					Quantity = quantity,
					Remarks = RemarkTextBox.Text,
					ItemCode = ItemCodeTextBox.Text,
					SupplierId = (int)SupplierComboBox.SelectedValue
				});
			}
			else
			{
				_dispatcher.DispatchCommand<AddComponentCommand>(new AddComponentCommand
				{
					Stocknr = StocknrTextBox.Text,
					Name = NameTextBox.Text,
					Price = price,
					MinimumStock = minimumstock,
					Quantity = quantity,
					Remarks = RemarkTextBox.Text,
					ItemCode = ItemCodeTextBox.Text,
					SupplierId = (int)SupplierComboBox.SelectedValue
				});
			}
		}

		private void CloseButton_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
