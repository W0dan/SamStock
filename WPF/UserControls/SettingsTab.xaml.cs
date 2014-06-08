using System.Windows;
using SAMStock.BO;
using SAMStock.wpf.UserControls.Base;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.UserControls
{
	public partial class SettingsTab : ISAMStockUserControl
	{
		public SettingsTab()
		{
			InitializeComponent();
			if (!Enviromment.IsInDesignTime)
			{
				Config.Modified += (x, y) => Refresh();
				Refresh();
			}
		}

		public void Refresh()
		{
			VatPercentageTextBox.Text = Config.VAT.ToString();
			DefaultPedalPriceMarginTextBox.Text = Config.DefaultPedalProfitMargin.ToString();
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			Config.VAT = VatPercentageTextBox.GetDecimal();
			Config.DefaultPedalProfitMargin = DefaultPedalPriceMarginTextBox.GetDecimal();
		}
	}
}
