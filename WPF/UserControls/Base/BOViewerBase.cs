using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SAMStock.Business.Foundation;

namespace WPF.UserControls.Base
{
	public abstract class BOViewerBase<TBO>: UserControl where TBO: IBusinessObject
	{
		protected TBO BO { get; set; }

		protected BOViewerBase()
		{
		} 

		protected BOViewerBase(TBO bo)
		{
			BO = bo;
		} 
	}
}
