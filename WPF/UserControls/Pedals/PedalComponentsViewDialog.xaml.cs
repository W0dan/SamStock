using System.Collections.Generic;
using System.Windows;
using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Pedals.RemoveComponent;
using WPF.Utilities;

namespace WPF.UserControls.Pedals
{
	public partial class PedalComponentsViewDialog : Window
	{
		private readonly Pedal _pedal;

		public PedalComponentsViewDialog(Pedal pedal)
		{
			_pedal = pedal;
			InitializeComponent();
			if (!Enviromment.IsInDesignTime)
			{
				Refresh();
			}
		}

		public void Refresh()
		{
			var model = (PedalComponentsView)DataContext;
			model.Components = _pedal.Components;
		}

		private void AddButton_OnClick(object sender, RoutedEventArgs e)
		{
			var dlg = new PedalComponentAddDialog(_pedal)
			{
				Owner = Application.Current.MainWindow
			};
			dlg.Show();
		}

		private void ModifyButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (ComponentsDataGrid.SelectedIndex != -1)
			{
				var pair = (KeyValuePair<Component, int>) ComponentsDataGrid.SelectedItem;
				var dlg = new PedalComponentUpdateDialog(_pedal, pair.Key, pair.Value)
				{
					Owner = Application.Current.MainWindow
				};
				dlg.Show();
			}
		}

		private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (ComponentsDataGrid.SelectedIndex != -1)
			{
				if (
					MessageBox.Show(Application.Current.MainWindow, "Are you sure you want to remove this component from this pedal?",
						"Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					SAMStock.Dispatcher.Command<RemoveComponentCommand, Pedal>(new RemoveComponentCommand(((Component)ComponentsDataGrid.SelectedItem).Id, _pedal.Id));
				}
			}
		}
	}
}
