using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using SAMStock.DAL.Pedal.AddPedal;
using SAMStock.DAL.Pedal.FilterPedal;
using SAMStock.DAL.Pedal.UpdatePedal;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.Dialogs
{
	/// <summary>
	/// Interaction logic for PedalViewWindow.xaml
	/// </summary>
	public partial class PedalViewWindow : Window
	{
		private readonly bool _editMode = false;
		private readonly FilterPedalResponsePedal _item;

		public PedalViewWindow()
		{
			InitializeComponent();
		}
		public PedalViewWindow(FilterPedalResponsePedal pedal): this()
		{
			_editMode = true;
			_item = pedal;

			NameTextBox.Text = _item.Name;
			PriceTextBox.Text = _item.Price.ToString(CultureInfo.InvariantCulture);
			MarginTextBox.Text = _item.Margin.ToString();
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
				SAMStockDispatcher.DispatchCommand<UpdatePedalCommand>(new UpdatePedalCommand
				{
					Id = _item.Id,
					Name = NameTextBox.Text,
					Price = price,
					Margin = margin
				});
			}
			else
			{
				SAMStockDispatcher.DispatchCommand<AddPedalCommand>(new AddPedalCommand
				{
					Name = NameTextBox.Text,
					Price = price,
					Margin = margin
				});
			}
		}

		private void CloseButton_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
