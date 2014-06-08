using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SAMStock.BO;
using SAMStock.wpf.Base;

namespace SAMStock.wpf.UserControls
{
	public class PedalsTabModel: BaseModel
	{
		private ObservableCollection<Pedal> _pedals = new ObservableCollection<Pedal>();
		public ObservableCollection<Pedal> Pedals
		{
			get { return _pedals; }
			set
			{
				_pedals = value;
				RaisePropertyChanged();
			}
		}  
	}
}
