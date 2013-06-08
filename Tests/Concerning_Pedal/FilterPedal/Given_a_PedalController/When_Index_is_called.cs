using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SamStock.Pedal.FilterPedal;
using SamStock.Web.Models;
using Moq;
using System.Web.Mvc;
using SamStock.Utilities;

namespace Tests.Concerning_Pedal.FilterPedal.Given_a_PedalController {
    [TestFixture]
    public class When_Index_is_called : PedalControllerBaseTest {
        private Mock<IFilterPedalHandler> _FilterPedalHandler;
        private ViewResult _result;
        private PedalViewModel _viewModel;
        private FilterPedalResponse _FilterPedalResponse;

        public override void Arrange() {
            _FilterPedalResponse = new FilterPedalResponse();
            _FilterPedalResponse.List.Add(new FilterPedalResponsePedal {
                Name = Guid.NewGuid().ToString(),
                Price = 5.0M,
                Margin = 2.0M,
                Id = 3
            });
            _FilterPedalResponse.List[0].List.Add(new FilterPedalResponseComponent {
                Stocknr = "ABC",
                Count = 5,
                Price = 1.0M
            });

            _FilterPedalHandler = new Mock<IFilterPedalHandler>();
            _FilterPedalHandler
                .Setup(x => x.Handle(It.IsAny<FilterPedalRequest>()))
                .Returns(_FilterPedalResponse);
            Container
                .Setup(x => x.Resolve<IQueryHandler<FilterPedalRequest, FilterPedalResponse>>())
                .Returns(_FilterPedalHandler.Object);
        }

        public override void Act() {
            _result = (ViewResult)Sut.Index();
            _viewModel = (PedalViewModel)_result.Model;
        }

        [Test]
        public void It_should_put_the_data_into_the_viewmodel() {
            Assert.AreEqual(_viewModel.List.Count,1);
            Assert.AreEqual(_viewModel.List[0].List.Count,1);
        }
    }
}
