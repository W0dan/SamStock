using System.Linq;
using System.Windows;
using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Components.Filter;
using SAMStock.DAL.Pedals.AddComponent;
using WPF.Utilities;

namespace WPF.UserControls.Pedals
{
	public partial class PedalComponentAddDialog : Window
	{
		private readonly Pedal _pedal;
		private readonly PedalComponentAdd _model;

		public PedalComponentAddDialog(Pedal pedal)
		{
			_pedal = pedal;
			InitializeComponent();
			_model = DataContext as PedalComponentAdd;
			if (!Enviromment.IsInDesignTime)
			{
				SAMStock.Dispatcher.Request<FilterComponentsRequest, FilterComponentsResponse>(new FilterComponentsRequest()).Items.ToList().ForEach(x => _model.Components.Add(x));
			}
		}

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			SAMStock.Dispatcher.Command<AddComponentCommand, Pedal>(new AddComponentCommand(_pedal.Id, (int) ComponentComboBox.SelectedValue, AmountTextBox.GetInt()));
			Close();
		}
	}
}
