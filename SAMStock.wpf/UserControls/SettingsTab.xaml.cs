using System;
using System.Collections.Generic;
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
		}

		private void SettingsTabItem_OnGotFocus(object sender, RoutedEventArgs e)
		{
			VatPercentageTextBox.Text = Properties.Settings.Default.VATPercentage.ToString();
			DefaultPedalPriceMarginTextBox.Text = Properties.Settings.Default.DefaultPedalPriceMargin.ToString();
		}

		private void VatPercentageTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			HandleSettingsInput(VatPercentageTextBox, "VATPercentage");
		}

		private void DefaultPedalPriceMarginTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			HandleSettingsInput(DefaultPedalPriceMarginTextBox, "DefaultPedalPriceMargin");
		}

		private void HandleSettingsInput(TextBox element, string branch)
		{
			double parsedInput;
			if (Double.TryParse(element.Text, out parsedInput))
			{
				Properties.Settings.Default[branch] = parsedInput;
				Properties.Settings.Default.Save();
			}
			else
			{
				DefaultPedalPriceMarginTextBox.Text = Properties.Settings.Default[branch].ToString();
			}
		}

		private void VatPercentageTextBox_OnGotFocus(object sender, RoutedEventArgs e)
		{
			VatPercentageTextBox.Select(0, VatPercentageTextBox.Text.Length);
		}

		private void DefaultPedalPriceMarginTextBox_OnGotFocus(object sender, RoutedEventArgs e)
		{
			DefaultPedalPriceMarginTextBox.Select(0, DefaultPedalPriceMarginTextBox.Text.Length);
		}
	}
}
