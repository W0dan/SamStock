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
using System.Windows.Shapes;
using SAMStock.DAL.Component.FilterComponent;
using SAMStock.DAL.Pedal.FilterPedal;

namespace SAMStock.wpf.Dialogs
{
	/// <summary>
	/// Interaction logic for PedalComponentsViewDialog.xaml
	/// </summary>
	public partial class PedalComponentsViewDialog : Window
	{
		private readonly FilterPedalResponsePedal _pedal;
		private readonly CollectionViewSource _components;

		public PedalComponentsViewDialog(FilterPedalResponsePedal pedal)
		{
			_pedal = pedal;
			InitializeComponent();
			_components = (CollectionViewSource)FindResource("Components");
			Refresh();
		}

		private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
		{
			Refresh();
		}

		private void Refresh()
		{
			_components.Source =
				SAMStockDispatcher.DispatchRequest<FilterComponentRequest, FilterComponentResponse>(new FilterComponentRequest
				{
					PedalId = _pedal.Id
				}).Components;
			ComponentsDataGrid.SelectedIndex = -1;
		}

		private void AddButton_OnClick(object sender, RoutedEventArgs e)
		{
			
		}

		private void ModifyButton_OnClick(object sender, RoutedEventArgs e)
		{
			var dlg = new PedalComponentsModifyDialog(_pedal)
			{
				Owner = Application.Current.MainWindow
			};
			dlg.Show();
		}

		private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
