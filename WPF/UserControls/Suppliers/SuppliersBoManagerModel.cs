using System.Collections.ObjectModel;
using SAMStock.BO;
using WPF.UserControls.Base;

namespace WPF.UserControls.Suppliers
{
    public class SuppliersBoManagerModel: BOManagerModelBase
    {
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
