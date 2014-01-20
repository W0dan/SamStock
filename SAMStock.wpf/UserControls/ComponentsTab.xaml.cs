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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SAMStock.DTO.Component.DeleteComponent;
using SAMStock.DTO.Component.DeleteComponent.Exceptions;
using SAMStock.DTO.Component.FilterComponent;
using SAMStock.Utilities;
using SAMStock.wpf.Castle;
using SAMStock.wpf.Dialogs;

namespace SAMStock.wpf.UserControls
{
	/// <summary>
	/// Interaction logic for ComponentsTab.xaml
	/// </summary>
	public partial class ComponentsTab : UserControl
	{
		private readonly IDispatcher _dispatcher = WindsorContainerStore.Container.Resolve<IDispatcher>();
		private readonly CollectionViewSource _componentsCollectionViewSource;

		public ComponentsTab()
		{
			InitializeComponent();
			_componentsCollectionViewSource = (CollectionViewSource)(FindResource("ComponentsCollectionViewSource"));
		}

		private void RefreshComponentsDataGrid()
		{
			_componentsCollectionViewSource.Source = _dispatcher.DispatchRequest<FilterComponentRequest, FilterComponentResponse>(new FilterComponentRequest()).Components;
			ComponentsDataGrid.SelectedIndex = -1;
		}

		private void ComponentsRefreshButton_OnClick(object sender, RoutedEventArgs e)
		{
			RefreshComponentsDataGrid();
		}

		private void ComponentsNewButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window dialog = new ComponentViewWindow();
			dialog.Owner = Application.Current.MainWindow;
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

				if (
					MessageBox.Show("Are you sure you want to delete " + ((FilterComponentResponseItem)ComponentsDataGrid.SelectedItem).ItemCode + "?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					try
					{
						_dispatcher.DispatchCommand<DeleteComponentCommand>(new DeleteComponentCommand
						{
							Id = ((FilterComponentResponseItem)ComponentsDataGrid.SelectedItem).Id
						});
						MessageBox.Show("Deletion completed");
					}
					catch (ComponentInUseException ex)
					{
						MessageBox.Show("Deletion failed: the following pedals rely on this component:");
					}
				}
				else
				{
					MessageBox.Show("Deletion cancelled");
				}
			}
			else
			{
				MessageBox.Show("No component selected");
			}
		}

		private void ComponentsTab_OnGotFocus(object sender, RoutedEventArgs e)
		{
			RefreshComponentsDataGrid();
		}
	}
}
