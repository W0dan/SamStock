﻿using System;
using System.Linq;
using System.Windows;
using SAMStock.BO;
using SAMStock.Business.Objects;
using SAMStock.DAL.Components.Create;
using SAMStock.DAL.Components.Update;
using SAMStock.DAL.Suppliers.Filter;
using WPF.UserControls.Base;
using WPF.Utilities;

namespace WPF.UserControls.Components
{
	public partial class ComponentViewDialog: BOViewerBase<Component>
	{
		private readonly bool _editMode = false;
		private readonly Component _comp;
		private readonly ComponentViewModel _model;

		public ComponentViewDialog()
		{
			InitializeComponent();
			_model = DataContext as ComponentViewModel;
			SAMStock.Dispatcher.Request<FilterSuppliersRequest, FilterSuppliersResponse>(new FilterSuppliersRequest()).Suppliers.ToList().ForEach(x => _model.Suppliers.Add(x));
		}

		public ComponentViewDialog(Component comp): this()
		{
			_editMode = true;
			_model.SaveButtonText = "Update";
			_comp = comp;

			StocknrTextBox.Text = _comp.StockNumber;
			NameTextBox.Text = _comp.Name;
			PriceTextBox.Text = _comp.Price.ToString();
			MinimumStockTextBox.Text = _comp.MinimumStock.ToString();
			QuantityTextBox.Text = _comp.Stock.ToString();
			RemarkTextBox.Text = _comp.Remarks;
			ItemCodeTextBox.Text = _comp.ItemCode;
			SupplierComboBox.SelectedIndex = _model.Suppliers.ToList().FindIndex(x => x.Id == _comp.Supplier.Id);
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			decimal price;
			try
			{
				price = PriceTextBox.GetDecimal();
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(String.Format("Price is not a valid number: {0}", ex.Message));
				return;
			}

			int minimumstock;
			try
			{
				minimumstock = MinimumStockTextBox.GetInt();
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(String.Format("Minimum Stock is not a valid number: {0}", ex.Message));
				return;
			}
			int quantity;
			try
			{
				quantity = QuantityTextBox.GetInt();
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(String.Format("Stock is not a valid number: {0}", ex.Message));
				return;
			}
			string itemcode;
			try
			{
				itemcode = ItemCodeTextBox.GetStringWithExactLength(7);
			}
			catch (ArgumentException)
			{
				MessageBox.Show(String.Format("Item Code {0} is not 7 characters", ItemCodeTextBox.Text));
				return;
			}
			if (_editMode)
			{
				SAMStock.Dispatcher.Command<UpdateComponentRequest, Component>(new UpdateComponentRequest(_comp.Id)
				{
					StockNumber = StocknrTextBox.Text,
					Name = NameTextBox.Text,
					Price = price,
					MinimumStock = minimumstock,
					Stock = quantity,
					Remarks = RemarkTextBox.Text,
					ItemCode = itemcode,
					SupplierId = (int)SupplierComboBox.SelectedValue
				});
			}
			else
			{
				SAMStock.Dispatcher.Command<CreateComponentRequest, Component>(new CreateComponentRequest(
					stocknumber: StocknrTextBox.Text,
					name: NameTextBox.Text,
					price: price,
					minimumstock: minimumstock,
					itemcode: itemcode,
					supplierid: (int) SupplierComboBox.SelectedValue
				)
				{
					Remarks = RemarkTextBox.Text,
					Stock = quantity
				});
			}
		}
	}
}
