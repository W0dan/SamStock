using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using System.Web.Mvc;
using SamStock.Pedal.AddPedal;
using SamStock.Utilities;
using SamStock.Web.Models.Pedal;
using SamStock.Pedal.FilterPedal;

namespace Tests.Concerning_Pedal.AddPedal.Given_a_PedalController
{
	[TestFixture]
	public class When_Create_is_called : PedalControllerBaseTest
	{
		private Mock<IAddPedalHandler> _handler;
		private PedalViewModelPedal p1;

		public override void Arrange()
		{
			_handler = new Mock<IAddPedalHandler>();
			Container
				.Setup(x => x.Resolve<ICommandHandler<AddPedalCommand>>())
				.Returns(_handler.Object);
			p1 = new PedalViewModelPedal(new FilterPedalResponsePedal
			{
				Name = "Blaster",
				Price = 50.0M,
				Margin = 25.0M,
				Id = 1
			});
		}

		public override void Act()
		{
			Sut.Create(p1);
		}

		[Test]
		public void It_should_call_Handle_on_the_Handler()
		{
			_handler.Verify(x => x.Handle(It.IsAny<AddPedalCommand>()));
		}

		[Test]
		public void It_should_include_all_the_data()
		{
			_handler.Verify(x => x.Handle(It.Is<AddPedalCommand>(y => y.Name == p1.Name && y.Margin == p1.Margin && y.Price == p1.Price)));
		}
	}
}
