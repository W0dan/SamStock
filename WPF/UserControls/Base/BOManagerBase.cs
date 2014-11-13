using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SAMStock;
using SAMStock.Business.Foundation;
using WPF.Annotations;

namespace WPF.UserControls.Base
{
	// ReSharper disable InconsistentNaming
	public abstract class BOManagerBase<TBO>: UserControl where TBO: IBusinessObject
	// ReSharper restore InconsistentNaming
	{
		public abstract void Refresh();
	}
}