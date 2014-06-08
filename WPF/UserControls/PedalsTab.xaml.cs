using System.Linq;
using System.Windows;
using SAMStock.BO;
using SAMStock.DAL.Pedals.Filter;
using SAMStock.wpf.Dialogs;
using SAMStock.wpf.UserControls.Base;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.UserControls
{
	public partial class PedalsTab : ISAMStockUserControl
	{
		private readonly PedalsTabModel _model;

		public PedalsTab()
		{
			InitializeComponent();
			_model = DataContext as PedalsTabModel;
			if (!Enviromment.IsInDesignTime)
			{
				Pedals.Created += (x, y) => Refresh();
				Pedals.Deleted += (x, y) => Refresh();
				Pedals.Updated += (x, y) => Refresh();
				Refresh();
			}
		}

		public void Refresh()
		{
			_model.Pedals.Clear();
			SAMStock.Dispatcher.Request<FilterPedalsRequest, FilterPedalsResponse>(new FilterPedalsRequest()).Items.ToList().ForEach(x => _model.Pedals.Add(x));
			PedalsDataGrid.SelectedIndex = -1;
		}

		private void PedalsNewButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window dialog = new PedalViewDialog
			{
				Owner = Application.Current.MainWindow
			};
			dialog.Show();
		}

		private void PedalsEditButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (PedalsDataGrid.SelectedIndex > -1)
			{
				Window dialog = new PedalViewDialog((Pedal)PedalsDataGrid.SelectedItem);
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
				var dlg = new PedalDeleteDialog((Pedal)PedalsDataGrid.SelectedItem)
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

		private void PedalComponentsManage_OnClick(object sender, RoutedEventArgs e)
		{
			if (PedalsDataGrid.SelectedIndex > -1)
			{
				var dlg = new PedalComponentsViewDialog((Pedal)PedalsDataGrid.SelectedItem)
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
