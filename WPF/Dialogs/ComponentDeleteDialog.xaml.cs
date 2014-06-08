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
using SAMStock.Castle;
using SAMStock.DAL.Components.Delete;
using SAMStock.Utilities;

namespace SAMStock.wpf.Dialogs
{
	/// <summary>
	/// Interaction logic for ComponentDeleteDialog.xaml
	/// </summary>
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
