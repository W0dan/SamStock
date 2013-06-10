namespace SamStock.Supplier.AddSupplier
{
    public class AddSupplierCommand
    {
        public AddSupplierCommand(string name, string address, string website)
        {
            Name = name;
            Address = address;
            Website = website;
        }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Website { get; private set; }
    }
}