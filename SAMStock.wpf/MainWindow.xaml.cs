using System.ComponentModel;
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
using SAMStock.Utilities;
using SAMStock.wpf.Installer;
using Component = Castle.MicroKernel.Registration.Component;

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
		}

		private void BootstrapWindsorContainer()
		{
			var container = new WindsorContainer();
			IoC.Container = container;
			container.Install(FromAssembly.This());

			_dispatcher = container.Resolve<IDispatcher>();
		}
	}
}
