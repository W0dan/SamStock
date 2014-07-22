using System.Windows;
using SAMStock.BO;
using SAMStock.DAL.Suppliers.Create;
using SAMStock.DAL.Suppliers.Update;

namespace WPF.UserControls.Suppliers
{
    public partial class SupplierViewDialog
    {
        private readonly bool _editMode = false;
		private readonly Supplier _supplier;

		public SupplierViewDialog()
		{
			InitializeComponent();
		}
		public SupplierViewDialog(Supplier supplier): this()
		{
			_editMode = true;
			_supplier = supplier;
			NameTextBox.Text = _supplier.Name;
			WebsiteTextBox.Text = _supplier.Website.ToString();
			AddressTextBox.Text = _supplier.Address.ToString();
		}

		

		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (_editMode)
			{
				SAMStock.Dispatcher.Command<UpdateSupplierCommand, Supplier>(new UpdateSupplierCommand(_supplier.Id)
				{
					Name = NameTextBox.Text,
					Website = WebsiteTextBox.Text,
					Address = AddressTextBox.Text
				});
			}
			else
			{
				SAMStock.Dispatcher.Command<CreateSupplierCommand, Supplier>(new CreateSupplierCommand(NameTextBox.Text, AddressTextBox.Text, WebsiteTextBox.Text));
			}
		}

		private void CloseButton_OnClick(object sender, RoutedEventArgs e)
		{
			Window.Close();
		}
	}
}
