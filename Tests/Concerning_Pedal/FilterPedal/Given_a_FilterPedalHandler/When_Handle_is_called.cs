using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAMStock.Pedal.FilterPedal;
using Moq;

namespace Tests.Concerning_Pedal.FilterPedal.Given_a_FilterPedalHandler
{
	[TestFixture]
	public class When_Handle_is_called : BaseTest
	{
		private FilterPedalRequest _request;
		private IFilterPedalHandler _sut;
		private Mock<IFilterPedalQueryExecutor> _queryexecutor;

		public override void Arrange()
		{
			_request = new FilterPedalRequest();
			_queryexecutor = new Mock<IFilterPedalQueryExecutor>();
			_sut = new FilterPedalHandler(_queryexecutor.Object);
		}

		public override void Act()
		{
			_sut.Handle(_request);
		}

		[Test]
		public void It_should_call_Execute_on_the_FilterPedalQueryExecutor()
		{
			_queryexecutor.Verify(x => x.Execute(_request));
		}
	}
}
