using System.Collections.ObjectModel;
using SAMStock.BO;
using WPF.Base;

namespace WPF.UserControls
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
