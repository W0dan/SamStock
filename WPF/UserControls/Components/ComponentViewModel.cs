using System.Collections.ObjectModel;
using SAMStock.BO;
using SAMStock.Business.Objects;
using WPF.UserControls.Base;

namespace WPF.UserControls.Components
{
	public class ComponentViewModel : BOManagerModelBase
	{
		private string _savebuttontext = "Save";
		public string SaveButtonText
		{
			get
			{
				return _savebuttontext;
			}
			set
			{
				_savebuttontext = value;
				RaisePropertyChanged();
			}
		}

		private ObservableCollection<Supplier> _suppliers = new ObservableCollection<Supplier>();

		public ObservableCollection<Supplier> Suppliers
		{
			get { return _suppliers; }
			set
			{
				_suppliers = value;
				RaisePropertyChanged();
			}
		}
	}
}