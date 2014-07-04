using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using SAMStock.BO;
using SAMStock.DAL.Components.Filter;
using SAMStock.DAL.Pedals.RemoveComponent;
using WPF.Utilities;

namespace WPF.Dialogs
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
				Pedals.Updated += (x,y) => Refresh();
			}
		}

		public void Refresh()
		{
			var model = (PedalComponentsViewModel)DataContext;
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
					SAMStock.Dispatcher.Command(new RemoveComponentCommand(((Component)ComponentsDataGrid.SelectedItem).Id, _pedal.Id));
				}
			}
		}
	}
}
