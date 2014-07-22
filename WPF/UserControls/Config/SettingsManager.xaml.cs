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
				SAMStock.BO.Config.Modified += (x, y) => Refresh();
				Refresh();
			}
		}

		public void Refresh()
		{
			VatPercentageTextBox.Text = SAMStock.BO.Config.VAT.ToString();
			DefaultPedalPriceMarginTextBox.Text = SAMStock.BO.Config.DefaultPedalProfitMargin.ToString();
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			SAMStock.BO.Config.VAT = VatPercentageTextBox.GetDecimal();
			SAMStock.BO.Config.DefaultPedalProfitMargin = DefaultPedalPriceMarginTextBox.GetDecimal();
		}
	}
}
