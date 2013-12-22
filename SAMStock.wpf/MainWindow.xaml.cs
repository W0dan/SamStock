using System.Collections.ObjectModel;
using System.ComponentModel;
using Castle.Components.DictionaryAdapter.Xml;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;
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
using SAMStock.Stock.FilterStock;
using SAMStock.Stock.ModifyStock;
using SAMStock.Stock.UpdateStock;
using SAMStock.Utilities;
using SAMStock.wpf.Castle;
using SAMStock.wpf.Stock;

namespace SAMStock.wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IDispatcher _dispatcher;

		public MainWindow()
		{
			InitializeComponent();
			BootstrapWindsorContainer();
			restoreWindowPosition();

			prepareStockTab();

			SetStatus("Ready");
		}

		private void prepareStockTab()
		{
			CollectionViewSource stockCollectionViewSource = (CollectionViewSource)(FindResource("StockCollectionViewSource"));
			stockCollectionViewSource.Source = _dispatcher.DispatchRequest<FilterStockRequest, FilterStockResponse>(new FilterStockRequest()).Components;
			StockDataGrid.SelectedIndex = -1;
		}

		private void restoreWindowPosition()
		{
			Top = Properties.Settings.Default.WindowTop;
			Left = Properties.Settings.Default.WindowLeft;
			Height = Properties.Settings.Default.WindowHeight;
			Width = Properties.Settings.Default.WindowWidth;
			WindowState = Properties.Settings.Default.WindowState;

			if (Top >= System.Windows.SystemParameters.VirtualScreenHeight || Top + Height <= 0)
			{
				Top = 100;
			}
			if (Left >= System.Windows.SystemParameters.VirtualScreenWidth || Left + Width <= 0)
			{
				Left = 100;
			}
		}

		private void SetStatus(string status)
		{
			StatusTextBlock.Text = status;
		}

		private void BootstrapWindsorContainer()
		{
			var container = new WindsorContainer();
			WindsorContainerStore.Container = container;
			container.Install(FromAssembly.This());

			_dispatcher = container.Resolve<IDispatcher>();
		}

		private void MainWindow_OnClosing(object sender, CancelEventArgs e)
		{
			if (WindowState != WindowState.Minimized)
			{
				Properties.Settings.Default.WindowState = WindowState;
				Properties.Settings.Default.WindowTop = Top;
				Properties.Settings.Default.WindowLeft = Left;
				Properties.Settings.Default.WindowHeight = Height;
				Properties.Settings.Default.WindowWidth = Width;
				Properties.Settings.Default.Save();
			}
		}

		private void SettingsTabItem_OnGotFocus(object sender, RoutedEventArgs e)
		{
			VatPercentageTextBox.Text = Properties.Settings.Default.VATPercentage.ToString();
			DefaultPedalPriceMarginTextBox.Text = Properties.Settings.Default.DefaultPedalPriceMargin.ToString();
		}

		private void VatPercentageTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			HandleSettingsInput(VatPercentageTextBox, "VATPercentage");
		}

		private void DefaultPedalPriceMarginTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			HandleSettingsInput(DefaultPedalPriceMarginTextBox, "DefaultPedalPriceMargin");
		}

		private void HandleSettingsInput(TextBox element, string branch)
		{
			double parsedInput;
			if (Double.TryParse(element.Text, out parsedInput))
			{
				Properties.Settings.Default[branch] = parsedInput;
				Properties.Settings.Default.Save();
			}
			else
			{
				DefaultPedalPriceMarginTextBox.Text = Properties.Settings.Default[branch].ToString();
			}
		}

		private void VatPercentageTextBox_OnGotFocus(object sender, RoutedEventArgs e)
		{
			VatPercentageTextBox.Select(0, VatPercentageTextBox.Text.Length);
		}

		private void DefaultPedalPriceMarginTextBox_OnGotFocus(object sender, RoutedEventArgs e)
		{
			DefaultPedalPriceMarginTextBox.Select(0, DefaultPedalPriceMarginTextBox.Text.Length);
		}

		private void StockNewButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window dialog = new StockItemView(_dispatcher);
			dialog.Owner = this;
			dialog.ShowDialog();
		}

		private void StockEditButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (StockDataGrid.SelectedIndex > -1)
			{
				Window dialog = new StockItemView(_dispatcher, ((FilterStockItem)StockDataGrid.SelectedItem).Id);
				dialog.Owner = this;
				dialog.ShowDialog();
			}
			else
			{
				MessageBox.Show("No component selected");
			}
		}

		private void StockDeleteButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (StockDataGrid.SelectedIndex > -1)
			{

				if (
					MessageBox.Show("Are you sure you want to delete " + ((FilterStockItem) StockDataGrid.SelectedItem).ItemCode + "?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					try
					{
						_dispatcher.DispatchCommand<ModifyStockCommand>(new ModifyStockCommand(((FilterStockItem) StockDataGrid.SelectedItem).Id, deleteoption: true));
						MessageBox.Show("Deletion completed");
					}
					catch (ComponentInUseException ex)
					{
						StringBuilder sb = new StringBuilder();
						foreach (string name in ex.PedalNames)
						{
							sb.Append("\n\t" + name);
						}
						MessageBox.Show("Deletion failed: the following pedals rely on this component:" + sb.ToString());
					}
				}
				else
				{
					MessageBox.Show("Deletion cancelled");
				}
			}
			else
			{
				MessageBox.Show("No component selected");
			}
		}
	}
}
