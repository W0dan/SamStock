using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SAMStock.Castle;
using SAMStock.Database;
using SAMStock.DTO.Component.DeleteComponent;
using SAMStock.DTO.Component.DeleteComponent.Exceptions;
using SAMStock.DTO.Component.FilterComponent;
using SAMStock.DTO.Supplier.FilterSuppliers;
using SAMStock.Utilities;
using SAMStock.wpf.Dialogs;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.UserControls
{
	/// <summary>
	/// Interaction logic for ComponentsTab.xaml
	/// </summary>
	public partial class ComponentsTab : UserControl
	{
		private readonly IDispatcher _dispatcher = WindsorContainerStore.Container.Resolve<IDispatcher>();
		private readonly CollectionViewSource _components;

		public ComponentsTab()
		{
			InitializeComponent();
			_components = (CollectionViewSource)FindResource("Components");
		}

		private void RefreshComponentsDataGrid()
		{
			SupplierIdToSupplierNameConverter.Suppliers =
				_dispatcher.DispatchRequest<FilterSuppliersRequest, FilterSuppliersResponse>(new FilterSuppliersRequest()).Suppliers;
			_components.Source =
				_dispatcher.DispatchRequest<FilterComponentRequest, FilterComponentResponse>(new FilterComponentRequest())
					.Components;
			
			ComponentsDataGrid.SelectedIndex = -1;
		}

		private void ComponentsRefreshButton_OnClick(object sender, RoutedEventArgs e)
		{
			RefreshComponentsDataGrid();
		}

		private void ComponentsNewButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window dialog = new ComponentViewWindow
			{
				Owner = Application.Current.MainWindow
			};
			dialog.Show();
		}

		private void ComponentsEditButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (ComponentsDataGrid.SelectedIndex > -1)
			{
				Window dialog = new ComponentViewWindow((FilterComponentResponseItem)ComponentsDataGrid.SelectedItem);
				dialog.Owner = Application.Current.MainWindow;
				dialog.Show();
			}
			else
			{
				MessageBox.Show("No component selected");
			}
		}

		private void ComponentsDeleteButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (ComponentsDataGrid.SelectedIndex > -1)
			{
				var dlg = new DeleteComponentDialog((FilterComponentResponseItem)ComponentsDataGrid.SelectedItem)
				{
					Owner = Application.Current.MainWindow
				};
				dlg.Show();
			}
			else
			{
				MessageBox.Show("No component selected");
			}
		}
	}
}