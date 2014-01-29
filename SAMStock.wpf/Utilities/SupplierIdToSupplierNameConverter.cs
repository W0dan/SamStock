using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SAMStock.DTO.Supplier.FilterSuppliers;
using SAMStock.Utilities;
using SAMStock.wpf.Castle;

namespace SAMStock.wpf.Utilities
{
	public class SupplierIdToSupplierNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return
				WindsorContainerStore.Container.Resolve<IDispatcher>()
					.DispatchRequest<FilterSuppliersRequest, FilterSuppliersResponse>(new FilterSuppliersRequest())
					.Suppliers.Single(x => x.Id == (int)value).Name;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
