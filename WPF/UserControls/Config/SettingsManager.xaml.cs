using System.Windows;
using WPF.UserControls.Base;
using WPF.Utilities;

namespace WPF.UserControls.Config
{
	public partial class SettingsManager
	{
		public SettingsManager()
		{
			InitializeComponent();
			if (!Enviromment.IsInDesignTime)
			{
				SAMStock.Business.Objects.Config.Modified += (x, y) => Refresh();
				Refresh();
			}
		}

		public void Refresh()
		{
			VatPercentageTextBox.Text = SAMStock.Business.Objects.Config.VAT.ToString();
			DefaultPedalPriceMarginTextBox.Text = SAMStock.Business.Objects.Config.DefaultPedalProfitMargin.ToString();
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			SAMStock.Business.Objects.Config.VAT = VatPercentageTextBox.GetDecimal();
			SAMStock.Business.Objects.Config.DefaultPedalProfitMargin = DefaultPedalPriceMarginTextBox.GetDecimal();
		}
	}
}
