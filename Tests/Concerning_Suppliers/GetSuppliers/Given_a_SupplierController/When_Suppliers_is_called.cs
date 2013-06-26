using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Supplier.GetSuppliers;
using SamStock.Utilities;
using SamStock.Web.Controllers;
using SamStock.Web.Models.Supplier;
using Tests._Util;

namespace Tests.Concerning_Suppliers.GetSuppliers.Given_a_SupplierController
{
	[TestFixture]
	public class When_Index_is_called : SupplierControllerBaseTest
	{
		private GetSuppliersResponse _response;
		private ViewResult _result;
		private SuppliersViewModel _viewModel;
		private Mock<IGetSuppliersHandler> _getLeveranciersHandler;

		public override void Arrange()
		{
			_response = new GetSuppliersResponse();

			_response.List = new List<GetSuppliersItem>();

			_response.List.Add(new GetSuppliersItem("dummy naam", "dummy adres", "dummy website"));
			_response.List.Add(new GetSuppliersItem("dummy naam1", "dummy adres1", "dummy website2"));

			_getLeveranciersHandler = new Mock<IGetSuppliersHandler>();
			_getLeveranciersHandler
				.Setup(x => x.Handle(It.IsAny<GetSuppliersRequest>()))
				.Returns(_response);

			Container
				.Setup(x => x.Resolve<IQueryHandler<GetSuppliersRequest, GetSuppliersResponse>>())
				.Returns(_getLeveranciersHandler.Object);
		}

		public override void Act()
		{
			_result = Sut.Index();
			_viewModel = (SuppliersViewModel)_result.Model;
		}

		[Test]
		public void It_should_put_the_leveranciers_in_the_viewmodel()
		{
			_viewModel.List.ShouldMatchAllItemsOf(_response.List, (x, y) => x.Address == y.Address);
		}
	}
}