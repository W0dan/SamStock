using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMStock.BO;
using WPF.Base;

namespace WPF.Dialogs
{
	public class PedalComponentsViewModel: BaseModel
	{
		private Dictionary<Component, int> _components = new Dictionary<Component, int>();

		public Dictionary<Component, int> Components
		{
			get { return _components; }
			set
			{
				_components = value;
				RaisePropertyChanged();
			}
		} 
	}
}
