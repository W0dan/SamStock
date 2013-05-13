using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Stock.FindMancos;
using SamStock.Utilities;
using SamStock.Web.Models;
using Tests._Util;

namespace Tests.Concerning_Stock.FindMancos.Given_a_StockController {
    public class When_Index_is_called : StockControllerBaseTest {
        private Mock<IFindMancosHandler> _FindMancosHandler;
        private ViewResult _result;
        private StockViewModel _viewModel;
        private FindMancosResponse _FindMancosResponse;

        public override void Arrange() {
            _FindMancosResponse = new FindMancosResponse();
            _FindMancosResponse.List = new List<FindMancosItem>
                {
                    new FindMancosItem
                        {
                            Hoeveelheid = 5,
                            LeverancierNaam = Guid.NewGuid().ToString(),
                            MinimumStock = 10,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = 12.25M,
                            Stocknr = Guid.NewGuid().ToString()
                        },
                    new FindMancosItem
                        {
                            Hoeveelheid = 2,
                            LeverancierNaam = Guid.NewGuid().ToString(),
                            MinimumStock = 10,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = 12.25M,
                            Stocknr = Guid.NewGuid().ToString()
                        },
                };

            _FindMancosHandler = new Mock<IFindMancosHandler>();
            _FindMancosHandler
                .Setup(x => x.Handle(It.IsAny<FindMancosRequest>()))
                .Returns(_FindMancosResponse);
            Container
                .Setup(x => x.Resolve<IQueryHandler<FindMancosRequest, FindMancosResponse>>())
                .Returns(_FindMancosHandler.Object);
        }

        public override void Act() {
            _result = Sut.Index();
            _viewModel = (StockViewModel)_result.Model;
        }

        [Test]
        public void It_should_put_the_data_into_the_viewmodel() {
            _viewModel.List.ShouldMatchAllItemsOf(_FindMancosResponse.List.ToList(),
                (x, y) => x.Stocknr == y.Stocknr
                    && x.Hoeveelheid == y.Hoeveelheid
                    && x.LeverancierNaam == y.LeverancierNaam
                    && x.MinimumStock == y.MinimumStock
                    && x.Naam == y.Naam
                    && x.Opmerkingen == y.Opmerkingen
                    && x.Prijs == y.Prijs
                );
        }
    }
}