using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SAMStock.BO;
using SAMStock.DAL.Components.Delete;
using SAMStock.DAL.Components.Filter;
using WPF.Dialogs.Base;
using WPF.Dialogs;
using WPF.UserControls.Base;
using WPF.Utilities;

namespace WPF.UserControls
{
	public partial class ComponentsTab : IInventoryListControl
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
				Window dialog = new ComponentViewDialog((Component)ComponentsDataGrid.SelectedItem);
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
				var component = (Component) ComponentsDataGrid.SelectedItem;
				if (MessageBox.Show(Application.Current.MainWindow, String.Format("Are you sure you want to delete {0}?", component.Name), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
				{
					SAMStock.Dispatcher.Command<DeleteComponentCommand, Component>(new DeleteComponentCommand(component.Id));
				}
			}
			else
			{
				MessageBox.Show("No component selected");
			}
		}
	}
}