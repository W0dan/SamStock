using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SAMStock.DTO.Supplier.FilterSuppliers;
using SAMStock.Utilities;

namespace SAMStock.wpf.Utilities
{
	public class SupplierIdToSupplierNameConverter : IValueConverter
	{
		public static List<FilterSuppliersResponseItem> Suppliers { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Suppliers.Single(x => x.Id == (int)value).Name;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}