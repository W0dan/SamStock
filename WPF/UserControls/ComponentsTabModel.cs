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
	public class ComponentsTabModel: BaseModel
	{
		private ObservableCollection<Component> _components = new ObservableCollection<Component>();

		public ObservableCollection<Component> Components
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
