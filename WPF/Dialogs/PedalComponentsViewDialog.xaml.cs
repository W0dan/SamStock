using System;
using System.Windows;
using System.Windows.Data;
using SAMStock.BO;
using SAMStock.DAL.Components.Filter;
using SAMStock.DAL.Pedals.RemoveComponent;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.Dialogs
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
				var model = (PedalComponentsViewModel)DataContext;
				_pedal.Components.ForEach(x => model.Components.Add(x));
			}
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
				var dlg = new PedalComponentUpdateDialog(_pedal, (Component)ComponentsDataGrid.SelectedItem)
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
