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
using SAMStock.DAL.Components.Filter;
using SAMStock.DAL.Pedals.AddComponent;
using WPF.Dialogs.Base;
using WPF.Utilities;

namespace WPF.Dialogs
{
	public partial class PedalComponentAddDialog : Window
	{
		private readonly Pedal _pedal;
		private readonly PedalComponentAddModel _model;

		public PedalComponentAddDialog(Pedal pedal)
		{
			_pedal = pedal;
			InitializeComponent();
			_model = DataContext as PedalComponentAddModel;
			if (!Enviromment.IsInDesignTime)
			{
				SAMStock.Dispatcher.Request<FilterComponentsRequest, FilterComponentsResponse>(new FilterComponentsRequest()).Items.ToList().ForEach(x => _model.Components.Add(x));
			}
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			SAMStock.Dispatcher.Command(new AddComponentCommand(_pedal.Id, (int) ComponentComboBox.SelectedValue, AmountTextBox.GetInt()));
			Close();
		}
	}
}
