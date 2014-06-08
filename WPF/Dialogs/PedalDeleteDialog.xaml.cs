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
using SAMStock.DAL.Pedals.Delete;

namespace SAMStock.wpf.Dialogs
{
	/// <summary>
	/// Interaction logic for PedalDeleteDialog.xaml
	/// </summary>
	public partial class PedalDeleteDialog : Window
	{
		private readonly Pedal _pedal;

		public PedalDeleteDialog(Pedal pedal)
		{
			_pedal = pedal;
			InitializeComponent();
			Warning.Content = string.Format("Are you sure you want to delete {0}?", pedal.Name);
		}

		private void CloseButton_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void OkButton_OnClick(object sender, RoutedEventArgs e)
		{
			SAMStock.Dispatcher.Command<DeletePedalCommand, Pedal>(new DeletePedalCommand(_pedal.Id));
			Close();
		}
	}
}
