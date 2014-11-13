using System.Windows;
using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Pedals.UpdateComponent;
using WPF.Utilities;

namespace WPF.UserControls.Pedals
{
	public partial class PedalComponentUpdateDialog
	{
		private readonly Pedal _pedal;
		private readonly Component _component;

		public PedalComponentUpdateDialog(Pedal pedal, Component component, int amount)
		{
			_pedal = pedal;
			_component = component;
			InitializeComponent();
			AmountTextBox.Text = amount.ToString();
		}

		private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
		{
			SAMStock.Dispatcher.Command<UpdateComponentCommand, Pedal>(new UpdateComponentCommand(_component.Id, _pedal.Id, AmountTextBox.GetInt()));
			Close();
		}
	}
}
