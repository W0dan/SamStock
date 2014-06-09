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
using System.Windows.Shapes;
using SAMStock.BO;
using SAMStock.DAL.Pedals.AddComponent;
using SAMStock.wpf.Dialogs.Base;
using SAMStock.wpf.Utilities;

namespace SAMStock.wpf.Dialogs
{
	public partial class PedalComponentAddDialog : Window
	{
		private readonly Pedal _pedal;

		public PedalComponentAddDialog(Pedal pedal)
		{
			_pedal = pedal;
			InitializeComponent();
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			SAMStock.Dispatcher.Command(new AddComponentCommand(_pedal.Id, (int) ComponentComboBox.SelectedValue,
				AmountTextBox.GetInt()));
			Close();
		}
	}
}
