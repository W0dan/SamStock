using System.Collections.ObjectModel;
using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using WPF.UserControls.Base;

namespace WPF.UserControls.Pedals
{
	public class PedalsBoManagerModel: BOManagerModelBase
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
