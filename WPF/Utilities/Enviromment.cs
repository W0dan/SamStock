using System.ComponentModel;
using System.Windows;

namespace SAMStock.wpf.Utilities
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
