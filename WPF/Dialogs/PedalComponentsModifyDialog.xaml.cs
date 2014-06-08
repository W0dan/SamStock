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
using SAMStock.BO;
using SAMStock.DAL.Components.Filter;
using SAMStock.DAL.Pedals.UpdateComponent;
using SAMStock.wpf.Exceptions;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.Dialogs
{
	public partial class PedalComponentsModifyDialog : Window
	{
		private readonly CollectionViewSource _components;
		private readonly Pedal _pedal;

		public PedalComponentsModifyDialog(Pedal pedal)
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
				SAMStock.Dispatcher.Command(new UpdateComponentCommand(
					componentid: ((BO.Component) ComponentsDataGrid.SelectedItem).Id,
					pedalid: _pedal.Id,
					amount: QuantityTextBox.GetInt()
					));
				Refresh();
			}
			catch (NumberFormatException)
			{
				MessageBox.Show(this, "Invalid number: " + QuantityTextBox.Text);
			}
		}

		private void ComponentsDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			QuantityTextBox.Text = ((BO.Component) ComponentsDataGrid.SelectedItem).Stock.ToString();
		}

		private void Refresh()
		{
			_components.Source = SAMStock.Dispatcher.Request<FilterComponentsRequest, FilterComponentsResponse>(new FilterComponentsRequest
				{
					PedalId = _pedal.Id
				}).Items;
			ComponentsDataGrid.SelectedIndex = -1;
		}
	}
}
