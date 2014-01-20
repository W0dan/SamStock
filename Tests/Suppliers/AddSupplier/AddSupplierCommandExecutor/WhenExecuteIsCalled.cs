using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.DTO.Supplier.AddSupplier;

namespace Tests.Suppliers.AddSupplier.AddSupplierCommandExecutor
{
    [TestFixture]
    public class WhenExecuteIsCalled : DatabaseTest
    {
        private SAMStock.DTO.Supplier.AddSupplier.AddSupplierCommandExecutor _sut;
        private AddSupplierCommand _cmd;


        public override void Arrange()
        {
            _cmd = new AddSupplierCommand
            {
	            Name = "Jos",
				Address = "somewhere",
				Website = "jos.be"
            };
            _sut = new SAMStock.DTO.Supplier.AddSupplier.AddSupplierCommandExecutor(Context);
        }

        public override void Act()
        {
            _sut.Execute(_cmd);
        }

        [Test]
        public void It_should_store_the_Supplier()
        {
	        Assert.IsTrue(Context.Supplier.Any(x => x.Name == _cmd.Name && x.Address == _cmd.Address && x.Website == _cmd.Website));
        }
    }
}