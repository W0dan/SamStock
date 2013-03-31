using NUnit.Framework;
using SamStock.Database;
using SamStock.Stock.GetStockOverzichtRefdata;
using System.Linq;

namespace Tests.Concerning_Stock.Given_a_GetStockRefdataQueryExecutor
{
    public class When_Execute_is_called : DatabaseTest
    {
        private string[] _leveranciers;
        private GetStockRefdataRequest _request;
        private GetStockRefdataQueryExecutor _sut;
        private GetStockRefdataResponse _result;

        public override void Arrange()
        {
            _leveranciers = new[] { "my leverancier1", "my leverancier2", "my leverancier3", "my leverancier4" };

            foreach (var leverancier in _leveranciers)
            {
                AddLeverancier(leverancier);
            }

            _request = new GetStockRefdataRequest();

            _sut = new GetStockRefdataQueryExecutor(Context);
        }

        private void AddLeverancier(string leverancierNaam)
        {
            var leverancier = new Leverancier { Naam = leverancierNaam };
            Context.Leverancier.AddObject(leverancier);
        }

        public override void Act()
        {
            _result = _sut.Execute(_request);
        }

        [Test]
        public void It_should_retrieve_the_leveranciers()
        {
            foreach (var leverancier in _leveranciers)
            {
                Assert.IsTrue(_result.List.Any(x => x.Naam == leverancier));
            }
        }

        [Test]
        public void It_should_return_valid_ids()
        {
            foreach (var item in _result.List)
            {
                Assert.IsTrue(item.Id > 0);
            }
        }
    }
}