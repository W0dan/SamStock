using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Stock.GetStockOverzicht;
using SamStock.Stock.GetStockOverzichtRefdata;
using SamStock.Utilities;
using SamStock.Web.Models;
using Tests._Util;

namespace Tests.Concerning_Stock.GetStockOverzicht.Given_a_StockController
{
    public class When_Index_is_called : StockControllerBaseTest
    {
        private Mock<IGetStockOverzichtHandler> _getStockOverzichtHandler;
        private ViewResult _result;
        private Mock<IGetStockRefdataHandler> _getRefdataHandler;
        private GetStockRefdataResponse _getStockRefdataResponse;
        private StockViewModel _viewModel;
        private GetStockOverzichtResponse _getStockOverzichtResponse;

        public override void Arrange()
        {
            _getStockRefdataResponse = new GetStockRefdataResponse();
            _getStockRefdataResponse.Leveranciers = new List<LeverancierRefdata>
                {
                    new LeverancierRefdata {Id = 1,Naam = "Musikding"},
                    new LeverancierRefdata {Id = 2,Naam = "nog een leverancier"},
                    new LeverancierRefdata {Id = 3,Naam = "een derde lev."},
                };

            _getStockOverzichtResponse = new GetStockOverzichtResponse();
            _getStockOverzichtResponse.List = new List<GetStockOverzichtItem>
                {
                    new GetStockOverzichtItem
                        {
                            Hoeveelheid = 125,
                            LeverancierNaam = Guid.NewGuid().ToString(),
                            MinimumStock = 12,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = 12.25M,
                            Stocknr = Guid.NewGuid().ToString()
                        },
                    new GetStockOverzichtItem
                        {
                            Hoeveelheid = 125,
                            LeverancierNaam = Guid.NewGuid().ToString(),
                            MinimumStock = 12,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = 12.25M,
                            Stocknr = Guid.NewGuid().ToString()
                        },
                };

            _getStockOverzichtHandler = new Mock<IGetStockOverzichtHandler>();
            _getStockOverzichtHandler
                .Setup(x => x.Handle(It.IsAny<GetStockOverzichtRequest>()))
                .Returns(_getStockOverzichtResponse);
            Container
                .Setup(x => x.Resolve<IQueryHandler<GetStockOverzichtRequest, GetStockOverzichtResponse>>())
                .Returns(_getStockOverzichtHandler.Object);

            _getRefdataHandler = new Mock<IGetStockRefdataHandler>();
            _getRefdataHandler
                .Setup(x => x.Handle(It.IsAny<GetStockRefdataRequest>()))
                .Returns(_getStockRefdataResponse);
            Container
                .Setup(x => x.Resolve<IQueryHandler<GetStockRefdataRequest, GetStockRefdataResponse>>())
                .Returns(_getRefdataHandler.Object);
        }

        public override void Act()
        {
            _result = Sut.Index();
            _viewModel = (StockViewModel)_result.Model;
        }

        [Test]
        public void It_should_put_the_refdata_into_the_viewmodel()
        {
            _viewModel.Leveranciers.ShouldMatchAllItemsOf(_getStockRefdataResponse.Leveranciers.ToList(), (x, y) => x.Id == y.Id && x.Naam == y.Name);
        }

        [Test]
        public void It_should_put_the_data_into_the_viewmodel()
        {
            _viewModel.List.ShouldMatchAllItemsOf(_getStockOverzichtResponse.List.ToList(), 
                (x, y) => x.Stocknr == y.Stocknr
                    && x.Hoeveelheid==y.Hoeveelheid
                    && x.LeverancierNaam == y.LeverancierNaam
                    && x.MinimumStock == y.MinimumStock
                    && x.Naam == y.Naam
                    && x.Opmerkingen == y.Opmerkingen
                    && x.Prijs == y.Prijs
                );
        }
    }
}