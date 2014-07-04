using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMStock.BO;
using WPF.Base;

namespace WPF.UserControls
{
    public class SuppliersTabModel: BaseModel
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
