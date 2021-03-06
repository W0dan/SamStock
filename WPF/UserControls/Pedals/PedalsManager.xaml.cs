﻿using System;
using System.Linq;
using System.Windows;
using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Pedals.Delete;
using SAMStock.DAL.Pedals.Filter;
using WPF.UserControls.Base;
using WPF.Utilities;

namespace WPF.UserControls.Pedals
{
	public partial class PedalsManager
	{
		private readonly PedalsBoManagerModel _model;

		public PedalsManager()
		{
			InitializeComponent();
			_model = DataContext as PedalsBoManagerModel;
			if (!Enviromment.IsInDesignTime)
			{
				Refresh();
			}
			SAMStock.Business.Managers.Pedals.Instance.Created += (sender, component) => Refresh();
			SAMStock.Business.Managers.Pedals.Instance.Deleted += (sender, id) => Refresh();
			SAMStock.Business.Managers.Pedals.Instance.Updated += (sender, component) => Refresh();
		}

		public void Refresh()
		{
			_model.Pedals.Clear();
			SAMStock.Dispatcher.Request<FilterPedalsRequest, FilterPedalsResponse>(new FilterPedalsRequest()).Pedals.ToList().ForEach(x => _model.Pedals.Add(x));
			PedalsDataGrid.SelectedIndex = -1;
		}

		private void PedalsNewButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window dialog = new WindowBase(new PedalViewDialog())
			{
				Owner = Application.Current.MainWindow
			};
			dialog.Show();
		}

		private void PedalsEditButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (PedalsDataGrid.SelectedIndex > -1)
			{
				var dialog = new WindowBase(new PedalViewDialog((Pedal) PedalsDataGrid.SelectedItem))
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
