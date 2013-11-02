using System.Linq;
using NUnit.Framework;
using SAMStock.Supplier.AddSupplier;

namespace Tests.Concerning_Suppliers.AddSupplier.Given_an_AddSupplierCommandExecutor
{
    [TestFixture]
    public class When_Execute_is_called : DatabaseTest
    {
        private string _name;
        private string _address;
        private string _website;
        private AddSupplierCommandExecutor _sut;
        private AddSupplierCommand _command;


        public override void Arrange()
        {
            _name = "jos";
            _address = "straat";
            _website = "bla.be";
            _command = new AddSupplierCommand(_name, _address, _website);
            _sut = new AddSupplierCommandExecutor(Context);
        }

        public override void Act()
        {
            _sut.Execute(_command);
        }

        [Test]
        public void It_should_put_the_name_of_the_leverancier_in_the_database()
        {
            var leverancier = Context.Supplier
                                    .ToList()
                                     .SingleOrDefault(l => l.Name == _name);

            Assert.IsNotNull(leverancier);
        }

        [Test]
        public void It_should_put_the_address_of_the_leverancier_in_the_database()
        {
            var leverancier = Context.Supplier.ToList()
                                     .SingleOrDefault(l => l.Address == _address);
            Assert.IsNotNull(leverancier);
        }

        [Test]
        public void It_should_put_the_website_of_the_leverancier_in_the_database()
        {
            var leverancier = Context.Supplier.ToList()
                                     .SingleOrDefault(l => l.Website == _website);
            Assert.IsNotNull(leverancier);
        }
    }
}