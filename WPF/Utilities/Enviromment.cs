using System.ComponentModel;
using System.Windows;

namespace WPF.Utilities
{
	internal static class Enviromment
	{
		internal static bool IsInDesignTime
		{
			get
			{
				return DesignerProperties.GetIsInDesignMode(new DependencyObject());
			}
		}
	}
}
