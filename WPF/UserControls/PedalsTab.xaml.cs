using System;
using System.Linq;
using System.Windows;
using SAMStock.BO;
using SAMStock.DAL.Pedals.Delete;
using SAMStock.DAL.Pedals.Filter;
using WPF.Dialogs;
using WPF.Dialogs.Base;
using WPF.UserControls.Base;
using WPF.Utilities;

namespace WPF.UserControls
{
	public partial class PedalsTab : IInventoryListControl
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
			Window dialog = new BaseWindow(new PedalViewDialog())
			{
				Owner = Application.Current.MainWindow
			};
			dialog.Show();
		}

		private void PedalsEditButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (PedalsDataGrid.SelectedIndex > -1)
			{
				var dialog = new BaseWindow(new PedalViewDialog((Pedal) PedalsDataGrid.SelectedItem))
				{
					Owner = Application.Current.MainWindow
				};
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
			    var pedal = (Pedal) PedalsDataGrid.SelectedItem;
			    if (MessageBox.Show(Application.Current.MainWindow, String.Format("Are you sure you want to delete {0}?", pedal.Name), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
			    {
				    SAMStock.Dispatcher.Command<DeletePedalCommand, Pedal>(new DeletePedalCommand(pedal.Id));
			    }
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
