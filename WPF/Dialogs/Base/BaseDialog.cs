using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Dialogs.Base
{
	public class BaseDialog : UserControl
	{
		protected Window Window;

		internal void RegisterWindow(Window window)
		{
			Window = window;
		}
	}
}
