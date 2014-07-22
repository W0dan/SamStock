using System.Windows;
using System.Windows.Controls;

namespace WPF.UserControls.Base
{
	public class DialogBase : UserControl
	{
		protected Window Window;

		internal void RegisterWindow(Window window)
		{
			Window = window;
		}
	}
}
