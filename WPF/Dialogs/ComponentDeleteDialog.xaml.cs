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
using SAMStock.Castle;
using SAMStock.DAL.Component.DeleteComponent;
using SAMStock.DAL.Component.DeleteComponent.Exceptions;
using SAMStock.DAL.Component.FilterComponent;
using SAMStock.Utilities;

namespace SAMStock.wpf.Dialogs
{
	/// <summary>
	/// Interaction logic for ComponentDeleteDialog.xaml
	/// </summary>
	public partial class ComponentDeleteDialog : Window
	{
		private readonly FilterComponentResponseComponent _item;

		public ComponentDeleteDialog(FilterComponentResponseComponent item)
		{
			_item = item;
			InitializeComponent();
			Warning.Content = string.Format("Are you sure you want to delete {0} ({1})?", item.Name, item.ItemCode);
		}

		private void CloseButton_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void OkButton_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				SAMStock.Dispatcher.Command(new DeleteComponentCommand
				{
					Id = _item.Id,
					Cascade = CascadeCheckBox.IsChecked.HasValue && CascadeCheckBox.IsChecked.Value
				});
				Close();
			}
			catch (ComponentInUseException ex)
			{
				MessageBox.Show("Deletion failed: the following pedals rely on this component:\n" + string.Join("\n", ex.PedalNames.ToArray()));
			}
		}
	}
}
