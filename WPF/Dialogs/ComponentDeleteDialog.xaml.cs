using System.Windows;
using SAMStock.BO;
using SAMStock.DAL.Components.Delete;

namespace SAMStock.wpf.Dialogs
{
	public partial class ComponentDeleteDialog : Window
	{
		private readonly Component _component;

		public ComponentDeleteDialog(Component component)
		{
			_component = component;
			InitializeComponent();
			Warning.Content = string.Format("Are you sure you want to delete {0} ({1})?", component.Name, component.ItemCode);
		}

		private void CloseButton_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void OkButton_OnClick(object sender, RoutedEventArgs e)
		{
			SAMStock.Dispatcher.Command<DeleteComponentCommand, Component>(new DeleteComponentCommand(_component.Id)
			{
				Cascade = CascadeCheckBox.IsChecked.HasValue && CascadeCheckBox.IsChecked.Value
			});
			Close();
		}
	}
}
