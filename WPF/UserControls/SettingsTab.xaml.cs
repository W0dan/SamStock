using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SAMStock.DAL.Admin.GetAdminData;
using SAMStock.DAL.Admin.SetAdminData;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.UserControls
{
	/// <summary>
	/// Interaction logic for SettingsTab.xaml
	/// </summary>
	public partial class SettingsTab : UserControl
	{
		public SettingsTab()
		{
			InitializeComponent();
			Refresh();
		}

		private void Refresh()
		{
			var settings = SAMStock.Dispatcher.Request<GetAdminDataRequest, GetAdminDataResponse>(new GetAdminDataRequest());
			VatPercentageTextBox.Text = settings.VAT.ToString(CultureInfo.InvariantCulture);
			DefaultPedalPriceMarginTextBox.Text = settings.DefaultPedalPriceMargin.ToString(CultureInfo.InvariantCulture);
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				SAMStock.Dispatcher.Command<SetAdminDataCommand>(new SetAdminDataCommand
				{
					VAT = VatPercentageTextBox.GetDecimal(),
					DefaultPedalPriceMargin = DefaultPedalPriceMarginTextBox.GetDecimal()
				});
			}
			catch (NumberFormatException)
			{}
			Refresh();
		}
	}
}
