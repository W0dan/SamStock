using System.Collections.ObjectModel;
using SAMStock.BO;
using WPF.Base;

namespace WPF.UserControls
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
