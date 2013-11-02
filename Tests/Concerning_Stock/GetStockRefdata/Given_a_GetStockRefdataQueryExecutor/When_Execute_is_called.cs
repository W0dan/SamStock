using NUnit.Framework;
using SAMStock.Database;
using SAMStock.Stock.GetStockRefdata;
using System.Linq;

namespace Tests.Concerning_Stock.GetStockRefdata.Given_a_GetStockRefdataQueryExecutor
{
    [TestFixture]
    public class When_Execute_is_called : DatabaseTest
    {
        private string[] _suppliers;
        private GetStockRefdataRequest _request;
        private GetStockRefdataQueryExecutor _sut;
        private GetStockRefdataResponse _result;

        public override void Arrange()
        {
            _suppliers = new[] { "my leverancier1", "my leverancier2", "my leverancier3", "my leverancier4" };

            foreach (var leverancier in _suppliers)
            {
                AddSupplier(leverancier);
            }

            _request = new GetStockRefdataRequest();

            _sut = new GetStockRefdataQueryExecutor(Context);
        }

        private void AddSupplier(string leverancierNaam)
        {
            var leverancier = new Supplier { Name = leverancierNaam };
            Context.Supplier.AddObject(leverancier);
        }

        public override void Act()
        {
            _result = _sut.Execute(_request);
        }

        [Test]
        public void It_should_retrieve_the_Suppliers()
        {
            foreach (var leverancier in _suppliers)
            {
                Assert.IsTrue(_result.Suppliers.Any(x => x.Name == leverancier));
            }
        }

        [Test]
        public void It_should_return_valid_ids()
        {
            foreach (var item in _result.Suppliers)
            {
                Assert.IsTrue(item.Id > 0);
            }
        }
    }
}