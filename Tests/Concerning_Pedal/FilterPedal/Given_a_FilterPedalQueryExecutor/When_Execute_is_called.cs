using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SamStock.Pedal.FilterPedal;
using SamStock.Database;

namespace Tests.Concerning_Pedal.FilterPedal.Given_a_FilterPedalQueryExecutor {
    [TestFixture]
    public class When_Execute_is_called : DatabaseTest {
        private IFilterPedalQueryExecutor _sut;
        private FilterPedalRequest _request;
        private FilterPedalResponse _response;

        public override void Arrange() {
            _request = new FilterPedalRequest(5);
            _sut = new FilterPedalQueryExecutor(Context);

            Context.Leverancier.AddObject(new Leverancier {
                Naam = "Jos",
                Id = 1,
                Adres = "somewhere"
            });
            Context.SaveChanges();

            Context.Component.AddObject(new Component {
                Stocknr = "ABC1",
                Prijs = 5.0M,
                LeverancierId = 1, // fk_comp_lev violation?
                Hoeveelheid = 20,
                MinimumStock = 15,
                Naam = "something",
                Id = 1,
                Opmerkingen = "blabla"
            });
            Context.SaveChanges();

            Context.Pedal.AddObject(new Pedal {
                Name = "Blaster",
                Id = 1,
                Price = 5.0M,
                Margin = 2.0M
            });
            Context.Pedal.AddObject(new Pedal {
                Name = "Fuzzer",
                Id = 2,
                Price = 10.0M,
                Margin = 7.0M
            });
            Context.SaveChanges();

            Context.PedalComponent.AddObject(new PedalComponent {
                Id = 1,
                PedalId = 1,
                ComponentId = 1,
                Number = 3
            });
            Context.SaveChanges();
        }

        public override void Act() {
            _response = _sut.Execute(_request);
        }

        [Test]
        public void It_should_return_1_item()
        {
            Assert.AreEqual(_response.List.Count,1);
        }

        [Test]
        public void It_should_contain_a_Pedal_called_Blaster()
        {
            Assert.IsTrue(_response.List.Any(x => x.Name == "Blaster"));
        }

        [Test]
        public void It_should_contain_a_Component_called_ABC1()
        {
            Assert.IsTrue(_response.List.Any(x => x.List.Any(y => y.Stocknr == "ABC1")));
        }
    }
}
