using System;
using System.Linq;
using System.Windows;
using SAMStock.BO;
using SAMStock.DAL.Suppliers.Delete;
using SAMStock.DAL.Suppliers.Filter;
using WPF.UserControls.Base;
using WPF.Utilities;

namespace WPF.UserControls.Suppliers
{
    public partial class SuppliersManager
    {
        private readonly SuppliersBoManagerModel _model;

        public SuppliersManager()
        {
            InitializeComponent();
            _model = DataContext as SuppliersBoManagerModel;
            if (!Enviromment.IsInDesignTime)
            {
                Refresh();
            }
        }

        private void SuppliersNewButton_OnClick(object sender, RoutedEventArgs e)
        {
			Window dialog = new WindowBase(new SupplierViewDialog())
			{
				Owner = Application.Current.MainWindow
			};
			dialog.Show();
        }

        private void SuppliersEditButton_OnClick(object sender, RoutedEventArgs e)
        {
			if (SuppliersDataGrid.SelectedIndex > -1)
			{
				var dialog = new WindowBase(new SupplierViewDialog((Supplier)SuppliersDataGrid.SelectedItem))
				{
					Owner = Application.Current.MainWindow
				};
				dialog.Show();
			}
			else
			{
				MessageBox.Show("No supplier selected");
			}
        }

        private void SuppliersDeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
			if (SuppliersDataGrid.SelectedIndex > -1)
			{
				var supplier = (Supplier)SuppliersDataGrid.SelectedItem;
				if (MessageBox.Show(Application.Current.MainWindow, String.Format("Are you sure you want to delete {0}?", supplier.Name), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
				{
					SAMStock.Dispatcher.Command<DeleteSupplierCommand, Supplier>(new DeleteSupplierCommand(supplier.Id));
				}
			}
			else
			{
				MessageBox.Show("No supplier selected");
			}
        }

        public void Refresh()
        {
            _model.Suppliers.Clear();
            SAMStock.Dispatcher.Request<FilterSuppliersRequest, FilterSuppliersResponse>(new FilterSuppliersRequest()).Items.ToList().ForEach(x => _model.Suppliers.Add(x));
            SuppliersDataGrid.SelectedIndex = -1;
        }
    }
}
