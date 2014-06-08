using System;
using System.Windows;
using System.Windows.Threading;

namespace SAMStock.wpf
{
	public partial class App : Application
	{
		public App()
		{
			// DispatcherUnhandledException += OnError;
		}

		void OnError(object sender, DispatcherUnhandledExceptionEventArgs exception)
		{
			exception.Handled = true;
			if (MessageBox.Show(String.Format("An exception has occurred!\n\n{0}\n\nClose the program?", exception.Exception.Message), exception.Exception.GetType().Name, MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
			{
				Shutdown();
			}
		}
	}
}
