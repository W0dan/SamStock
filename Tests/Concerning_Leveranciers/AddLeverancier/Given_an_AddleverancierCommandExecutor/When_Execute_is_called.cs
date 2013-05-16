using System.Linq;
using NUnit.Framework;
using SamStock.Beheer.Leveranciers.AddLeverancier;

namespace Tests.Concerning_Leveranciers.AddLeverancier.Given_an_AddleverancierCommandExecutor
{
    [TestFixture]
    public class When_Execute_is_called : DatabaseTest
    {
        private string _name;
        private string _address;
        private string _website;
        private AddLeverancierCommandExecutor _sut;
        private AddLeverancierCommand _command;


        public override void Arrange()
        {
            _name = "jos";
            _address = "straat";
            _website = "bla.be";
            _command = new AddLeverancierCommand(_name, _address, _website);
            _sut = new AddLeverancierCommandExecutor(Context);
        }

        public override void Act()
        {
            _sut.Execute(_command);
        }

        [Test]
        public void It_should_put_the_name_of_the_leverancier_in_the_database()
        {
            var leverancier = Context.Leverancier
                                    .ToList()
                                     .SingleOrDefault(l => l.Naam == _name);

            Assert.IsNotNull(leverancier);
        }

        [Test]
        public void It_should_put_the_address_of_the_leverancier_in_the_database()
        {
            var leverancier = Context.Leverancier.ToList()
                                     .SingleOrDefault(l => l.Adres == _address);
            Assert.IsNotNull(leverancier);
        }

        [Test]
        public void It_should_put_the_website_of_the_leverancier_in_the_database()
        {
            var leverancier = Context.Leverancier.ToList()
                                     .SingleOrDefault(l => l.Site == _website);
            Assert.IsNotNull(leverancier);
        }
    }
}