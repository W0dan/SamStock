using System.Collections.ObjectModel;
using SAMStock.BO;
using WPF.UserControls.Base;

namespace WPF.UserControls.Components
{
	public class ComponentsManagerModel: BOManagerModelBase
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
