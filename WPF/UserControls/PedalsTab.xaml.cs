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
				Window dialog = new PedalViewDialog((BO.Pedal)PedalsDataGrid.SelectedItem);
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
				var dlg = new PedalDeleteDialog((BO.Pedal)PedalsDataGrid.SelectedItem)
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
				var dlg = new PedalComponentsViewDialog((BO.Pedal)PedalsDataGrid.SelectedItem)
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
