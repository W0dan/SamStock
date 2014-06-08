using System.Collections.ObjectModel;
using SAMStock.BO;
using SAMStock.wpf.Base;

namespace SAMStock.wpf.Dialogs
{
	public class ComponentViewModel : BaseModel
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