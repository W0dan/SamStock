using System.Collections.Generic;
using SAMStock.BO;
using SAMStock.Business.Objects;
using WPF.UserControls.Base;

namespace WPF.UserControls.Pedals
{
	public class PedalComponentsView: BOManagerModelBase
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
