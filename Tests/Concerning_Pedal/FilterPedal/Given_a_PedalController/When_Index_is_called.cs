using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SamStock.Pedal.FilterPedal;
using SamStock.Web.Models.Pedal;
using Moq;
using System.Web.Mvc;
using SamStock.Utilities;
using SamStock.Admin.GetAdminData;

namespace Tests.Concerning_Pedal.FilterPedal.Given_a_PedalController
{
	[TestFixture]
	public class When_Index_is_called : PedalControllerBaseTest
	{
		private Mock<IFilterPedalHandler> _FilterPedalHandler;
		private Mock<IGetAdminDataHandler> _AdminDataHandler;
		private ViewResult _result;
		private PedalViewModel _viewModel;
		private FilterPedalResponse _FilterPedalResponse;
		private GetAdminDataResponse _AdminData;
		private FilterPedalResponsePedal p1;
		private FilterPedalResponseComponent pc1;

		public override void Arrange()
		{
			_FilterPedalResponse = new FilterPedalResponse();
			p1 = new FilterPedalResponsePedal
			{
				Name = Guid.NewGuid().ToString(),
				Price = 5.0M,
				Margin = 2.0M,
				Id = 3
			};
			_FilterPedalResponse.List.Add(p1);
			pc1 = new FilterPedalResponseComponent
			{
				Stocknr = "ABC",
				Quantity = 5,
				Price = 1.0M
			};
			_FilterPedalResponse.List[0].List.Add(pc1);

			_AdminData = new GetAdminDataResponse(21.0M, 50.0M);

			_FilterPedalHandler = new Mock<IFilterPedalHandler>();
			_FilterPedalHandler
				.Setup(x => x.Handle(It.IsAny<FilterPedalRequest>()))
				.Returns(_FilterPedalResponse);
			Container
				.Setup(x => x.Resolve<IQueryHandler<FilterPedalRequest, FilterPedalResponse>>())
				.Returns(_FilterPedalHandler.Object);

			_AdminDataHandler = new Mock<IGetAdminDataHandler>();
			_AdminDataHandler
				.Setup(x => x.Handle(It.IsAny<GetAdminDataRequest>()))
				.Returns(_AdminData);
			Container
				.Setup(x => x.Resolve<IQueryHandler<GetAdminDataRequest, GetAdminDataResponse>>())
				.Returns(_AdminDataHandler.Object);
		}

		public override void Act()
		{
			_result = (ViewResult)Sut.Index();
			_viewModel = (PedalViewModel)_result.Model;
		}

		[Test]
		public void It_should_put_the_pedal_into_the_viewmodel()
		{
			var vmp = _viewModel.List[0];
			Assert.IsTrue(vmp.Id == p1.Id && vmp.Margin == p1.Margin && vmp.Name == p1.Name && vmp.Price == p1.Price);
		}

		[Test]
		public void It_should_put_the_component_into_the_viewmodel()
		{
			var vmc = _viewModel.List[0].List[0];
			Assert.IsTrue(vmc.Description == pc1.Description && vmc.Price == pc1.Price && vmc.Quantity == pc1.Quantity && vmc.Stock == pc1.Stock && vmc.Stocknr == pc1.Stocknr);
		}

		[Test]
		public void It_should_put_the_admindata_into_the_viewmodel()
		{
			Assert.IsTrue(_viewModel.VAT == _AdminData.VAT && _viewModel.List[0].Margin > -1);
			// margin can be pedal-specific
		}
	}
}
