﻿using System.ComponentModel;
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
using SAMStock.Utilities;
using SAMStock.wpf.Castle;

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
	}
}
