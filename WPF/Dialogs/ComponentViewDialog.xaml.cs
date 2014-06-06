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
using SAMStock.Castle;
using SAMStock.Database;
using SAMStock.DAL.Component.AddComponent;
using SAMStock.DAL.Component.FilterComponent;
using SAMStock.DAL.Component.UpdateComponent;
using SAMStock.DAL.Supplier.FilterSuppliers;
using SAMStock.Utilities;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.Dialogs
{
	/// <summary>
	/// Interaction logic for ComponentViewDialog.xaml
	/// </summary>
	public partial class ComponentViewDialog : Window
	{
		private readonly bool _editMode = false;
		private readonly FilterComponentResponseComponent _comp;
		private readonly CollectionViewSource _suppliers;

		public ComponentViewDialog()
		{
			InitializeComponent();
			_suppliers = (CollectionViewSource)FindResource("Suppliers");
			_suppliers.Source =
				SAMStock.Dispatcher.Request<FilterSuppliersRequest, FilterSuppliersResponse>(new FilterSuppliersRequest())
					.Suppliers;
		}

		public ComponentViewDialog(FilterComponentResponseComponent comp): this()
		{
			_editMode = true;
			_comp = comp;

			StocknrTextBox.Text = _comp.Stocknr;
			NameTextBox.Text = _comp.Name;
			PriceTextBox.Text = _comp.Price.ToString(CultureInfo.CurrentCulture);
			MinimumStockTextBox.Text = _comp.MinimumStock.ToString(CultureInfo.CurrentCulture);
			QuantityTextBox.Text = _comp.Quantity.ToString(CultureInfo.CurrentCulture);
			RemarkTextBox.Text = _comp.Remark;
			ItemCodeTextBox.Text = _comp.ItemCode;
			SupplierComboBox.SelectedIndex = ((List<FilterSuppliersResponseItem>) _suppliers.Source).FindIndex(x => x.Id == _comp.SupplierId);
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			decimal price;
			try
			{
				price = PriceTextBox.GetDecimal();
			}
			catch (NumberFormatException)
			{
				MessageBox.Show("Price is not a valid number");
				return;
			}

			int minimumstock;
			try
			{
				minimumstock = MinimumStockTextBox.GetInt();
			}
			catch (NumberFormatException)
			{
				MessageBox.Show("Minimum Stock is not a valid number");
				return;
			}
			int quantity;
			try
			{
				quantity = QuantityTextBox.GetInt();
			}
			catch (NumberFormatException)
			{
				MessageBox.Show("Quantity is not a valid number");
				return;
			}
			string itemcode;
			try
			{
				itemcode = ItemCodeTextBox.GetStringWithExactLength(7);
			}
			catch (IllegalInputException)
			{
				MessageBox.Show("Item Code is not 7 characters");
				return;
			}
			if (_editMode)
			{
				SAMStock.Dispatcher.Command<UpdateComponentCommand>(new UpdateComponentCommand
				{
					Id = _comp.Id,
					Stocknr = StocknrTextBox.Text,
					Name = NameTextBox.Text,
					Price = price,
					MinimumStock = minimumstock,
					Quantity = quantity,
					Remarks = RemarkTextBox.Text,
					ItemCode = itemcode,
					SupplierId = (int)SupplierComboBox.SelectedValue
				});
			}
			else
			{
				SAMStock.Dispatcher.Command<AddComponentCommand>(new AddComponentCommand
				{
					Stocknr = StocknrTextBox.Text,
					Name = NameTextBox.Text,
					Price = price,
					MinimumStock = minimumstock,
					Quantity = quantity,
					Remarks = RemarkTextBox.Text,
					ItemCode = itemcode,
					SupplierId = (int) SupplierComboBox.SelectedValue
				});
			}
		}

		private void CloseButton_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
