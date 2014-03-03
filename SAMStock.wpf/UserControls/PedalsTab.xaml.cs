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
using SAMStock.DAL.Pedal.FilterPedal;
using SAMStock.wpf.Dialogs;

namespace SAMStock.wpf.UserControls
{
	/// <summary>
	/// Interaction logic for PedalsTab.xaml
	/// </summary>
	public partial class PedalsTab : UserControl
	{
		private readonly CollectionViewSource _pedals;

		public PedalsTab()
		{
			InitializeComponent();
			_pedals = (CollectionViewSource)FindResource("Pedals");
		}

		private void RefreshPedalsDataGrid()
		{
			_pedals.Source =
				SAMStockDispatcher.DispatchRequest<FilterPedalRequest, FilterPedalResponse>(new FilterPedalRequest())
					.Pedals;
			PedalsDataGrid.SelectedIndex = -1;
		}

		private void PedalsRefreshButton_OnClick(object sender, RoutedEventArgs e)
		{
			RefreshPedalsDataGrid();
		}

		private void PedalsNewButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window dialog = new PedalViewWindow
			{
				Owner = Application.Current.MainWindow
			};
			dialog.Show();
		}

		private void PedalsEditButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (PedalsDataGrid.SelectedIndex > -1)
			{
				Window dialog = new PedalViewWindow((FilterPedalResponsePedal)PedalsDataGrid.SelectedItem);
				dialog.Owner = Application.Current.MainWindow;
				dialog.Show();
			}
			else
			{
				MessageBox.Show("No pedal selected");
			}
		}

		private void PedalsDeleteButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (PedalsDataGrid.SelectedIndex > -1)
			{
				var dlg = new DeletePedalDialog((FilterPedalResponsePedal)PedalsDataGrid.SelectedItem)
				{
					Owner = Application.Current.MainWindow
				};
				dlg.Show();
			}
			else
			{
				MessageBox.Show("No pedal selected");
			}
		}
	}
}
