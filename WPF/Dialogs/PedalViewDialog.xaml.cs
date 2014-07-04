using System.Globalization;
using System.Windows;
using SAMStock.BO;
using SAMStock.DAL.Pedals.Create;
using SAMStock.DAL.Pedals.Update;
using WPF.Utilities;
using WPF.Exceptions;

namespace WPF.Dialogs
{
	public partial class PedalViewDialog
	{
		private readonly bool _editMode = false;
		private readonly Pedal _pedal;

		public PedalViewDialog()
		{
			InitializeComponent();
		}
		public PedalViewDialog(Pedal pedal): this()
		{
			_editMode = true;
			_pedal = pedal;
			NameTextBox.Text = _pedal.Name;
			PriceTextBox.Text = _pedal.Price.ToString();
			MarginTextBox.Text = _pedal.ProfitMargin.ToString();
		}

		

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			decimal price;
			try
			{
				price = PriceTextBox.GetDecimal();
			}
			catch (NumberFormatException)
			{
				MessageBox.Show("Price is not a valid number");
				return;
			}

			var margin = new decimal?();
			if (!MarginTextBox.Text.Equals(""))
			{
				try
				{
					margin = MarginTextBox.GetDecimal();
				}
				catch (NumberFormatException)
				{
					MessageBox.Show("Margin is not a valid number");
					return;
				}
			}
			if (_editMode)
			{
				SAMStock.Dispatcher.Command<UpdatePedalCommand, Pedal>(new UpdatePedalCommand(_pedal.Id)
				{
					Name = NameTextBox.Text,
					Price = price,
					ProfitMargin = margin
				});
			}
			else
			{
				SAMStock.Dispatcher.Command<CreatePedalCommand, Pedal>(new CreatePedalCommand(
					name: NameTextBox.Text,
					price: price
				)
				{
					ProfitMargin = margin
				});
			}
		}

		private void CloseButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window.Close();
		}
	}
}
