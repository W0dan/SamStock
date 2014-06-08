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
using SAMStock.BO;
using SAMStock.Castle;
using SAMStock.DAL.Components.Filter;
using SAMStock.Database;
using SAMStock.Utilities;
using SAMStock.wpf.Dialogs;
using SAMStock.wpf.UserControls.Base;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.UserControls
{
	public partial class ComponentsTab : ISAMStockUserControl
	{
		private readonly ComponentsTabModel _model;

		public ComponentsTab()
		{
			
			InitializeComponent();
			_model = DataContext as ComponentsTabModel;
			if (!Enviromment.IsInDesignTime)
			{
				Components.Created += (x, y) => Refresh();
				Components.Deleted += (x, y) => Refresh();
				Components.Updated += (x, y) => Refresh();
				Refresh();
			}
		}

		public void Refresh()
		{
			_model.Components.Clear();
			SAMStock.Dispatcher.Request<FilterComponentsRequest, FilterComponentsResponse>(new FilterComponentsRequest()).Items.ToList().ForEach(x => _model.Components.Add(x));
			ComponentsDataGrid.SelectedIndex = -1;
		}

		private void ComponentsNewButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window dialog = new ComponentViewDialog
			{
				Owner = Application.Current.MainWindow
			};
			dialog.Show();
		}

		private void ComponentsEditButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (ComponentsDataGrid.SelectedIndex > -1)
			{
				Window dialog = new ComponentViewDialog((BO.Component)ComponentsDataGrid.SelectedItem);
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
				var dlg = new ComponentDeleteDialog((BO.Component)ComponentsDataGrid.SelectedItem)
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