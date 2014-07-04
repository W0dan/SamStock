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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SAMStock.BO;
using SAMStock.DAL.Suppliers.Delete;
using SAMStock.DAL.Suppliers.Filter;
using WPF.Dialogs;
using WPF.Dialogs.Base;
using WPF.UserControls.Base;
using WPF.Utilities;

namespace WPF.UserControls
{
    public partial class SuppliersTab : IInventoryListControl
    {
        private readonly SuppliersTabModel _model;

        public SuppliersTab()
        {
            InitializeComponent();
            _model = DataContext as SuppliersTabModel;
            if (!Enviromment.IsInDesignTime)
            {
                Suppliers.Created += (x, y) => Refresh();
                Suppliers.Deleted += (x, y) => Refresh();
                Suppliers.Updated += (x, y) => Refresh();
                Refresh();
            }
        }

        private void SuppliersNewButton_OnClick(object sender, RoutedEventArgs e)
        {
			Window dialog = new BaseWindow(new SupplierViewDialog())
			{
				Owner = Application.Current.MainWindow
			};
			dialog.Show();
        }

        private void SuppliersEditButton_OnClick(object sender, RoutedEventArgs e)
        {
			if (SuppliersDataGrid.SelectedIndex > -1)
			{
				var dialog = new BaseWindow(new SupplierViewDialog((Supplier)SuppliersDataGrid.SelectedItem))
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
