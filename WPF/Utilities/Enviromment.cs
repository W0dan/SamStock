using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAMStock.wpf.Utilities
{
	internal static class Enviromment
	{
		internal static bool IsInDesignTime
		{
			get
			{
				return System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
			}
		}
	}
}
