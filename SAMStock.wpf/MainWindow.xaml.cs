using SamStock.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAMStock.wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IDispatcher _dispatcher;

		public MainWindow(Dispatcher dispatcher)
		{
			_dispatcher = dispatcher;
			InitializeComponent();

			Top = System.Windows.SystemParameters.VirtualScreenHeight < Properties.Settings.Default.WindowTop + Properties.Settings.Default.WindowHeight / 2 || Properties.Settings.Default.WindowTop + Properties.Settings.Default.WindowHeight / 2 < 0 ? 0 : Properties.Settings.Default.WindowTop;
			Left = System.Windows.SystemParameters.VirtualScreenWidth < Properties.Settings.Default.WindowLeft + Properties.Settings.Default.WindowWidth / 2 || Properties.Settings.Default.WindowLeft + Properties.Settings.Default.WindowWidth / 2 < 0 ? 0 : Properties.Settings.Default.WindowLeft;
			Height = Properties.Settings.Default.WindowHeight;
			Width = Properties.Settings.Default.WindowWidth;
			WindowState = Properties.Settings.Default.WindowState;
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Properties.Settings.Default.WindowTop = Top;
			Properties.Settings.Default.WindowLeft = Left;
			Properties.Settings.Default.WindowHeight = Height;
			Properties.Settings.Default.WindowWidth = Width;
			Properties.Settings.Default.WindowState = WindowState;
			Properties.Settings.Default.Save();
		}

		private void ButtonConfigFinancialSave_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Grid_GotFocus(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("hi");
		}
	}
}
