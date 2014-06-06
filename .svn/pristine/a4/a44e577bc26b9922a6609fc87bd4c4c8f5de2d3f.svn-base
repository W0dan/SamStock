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
using System.Windows.Shapes;
using SAMStock.DAL.Pedal.FilterComponent;
using SAMStock.DAL.Pedal.FilterPedal;
using SAMStock.DAL.Pedal.UpdateComponent;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.Dialogs
{
	/// <summary>
	/// Interaction logic for PedalComponentsModifyDialog.xaml
	/// </summary>
	public partial class PedalComponentsModifyDialog : Window
	{
		private readonly CollectionViewSource _components;
		private readonly FilterPedalResponsePedal _pedal;

		public PedalComponentsModifyDialog(FilterPedalResponsePedal pedal)
		{
			InitializeComponent();
			_components = (CollectionViewSource)FindResource("Components");
			_pedal = pedal;
			Refresh();
		}

		private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				SAMStockDispatcher.DispatchCommand(new UpdateComponentCommand
				{
					PedalId = _pedal.Id,
					ComponentId = ((FilterComponentResponseComponent) ComponentsDataGrid.SelectedItem).Id,
					Quantity = QuantityTextBox.GetInt()
				});
				Refresh();
			}
			catch (NumberFormatException)
			{
				MessageBox.Show(this, "Invalid number");
			}
		}

		private void ComponentsDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			QuantityTextBox.Text =
				((FilterComponentResponseComponent) ComponentsDataGrid.SelectedItem).Quantity.ToString(CultureInfo.InvariantCulture);
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
	}
}
