using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Stock.FilterStock;
using SamStock.Stock.GetStockOverzichtRefdata;
using SamStock.Utilities;
using SamStock.Web.Models;
using Tests._Util;
using SamStock.Stock.GetStockOverzicht;

namespace Tests.Concerning_Stock.FilterStock.Given_a_StockController
{
    [TestFixture]
    public class When_Index_is_called : StockControllerBaseTest
    {
        private Mock<IFilterStockHandler> _FilterStockHandler;
        private Mock<IGetStockOverzichtHandler> _GetStockOverzichtHandler;
        private ViewResult _result;
        private StockViewModel _viewModel;
        private FilterStockResponse _FilterStockResponse;
        private GetStockOverzichtResponse _GetStockOverzichtResponse;
        private Mock<IGetStockRefdataHandler> _getRefdataHandler;
        private GetStockRefdataResponse _getStockRefdataResponse;

        public override void Arrange()
        {
            _FilterStockResponse = new FilterStockResponse();
            FilterStockItem i1 = new FilterStockItem
                        {
                            Hoeveelheid = 5,
                            LeverancierNaam = Guid.NewGuid().ToString(),
                            MinimumStock = 10,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = 12.25M,
                            Stocknr = Guid.NewGuid().ToString()
                        };
            FilterStockItem i2 = new FilterStockItem
                        {
                            Hoeveelheid = 2,
                            LeverancierNaam = Guid.NewGuid().ToString(),
                            MinimumStock = 10,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = 12.25M,
                            Stocknr = Guid.NewGuid().ToString()
                        };
            _FilterStockResponse.List = new List<FilterStockItem>
                {
                    i1,i2
                };

            _GetStockOverzichtResponse = new GetStockOverzichtResponse();
            _GetStockOverzichtResponse.List = new List<GetStockOverzichtItem>
                {
                    new GetStockOverzichtItem
                        {
                            Hoeveelheid = i1.Hoeveelheid,
                            LeverancierNaam = Guid.NewGuid().ToString(),
                            MinimumStock = i1.MinimumStock,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = i1.Prijs,
                            Stocknr = Guid.NewGuid().ToString()
                        },
                    new GetStockOverzichtItem
                        {
                            Hoeveelheid = i2.Hoeveelheid,
                            LeverancierNaam = Guid.NewGuid().ToString(),
                            MinimumStock = i2.MinimumStock,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = i2.Prijs,
                            Stocknr = Guid.NewGuid().ToString()
                        },
                    new GetStockOverzichtItem // not a manco, on purpose
                        {
                            Hoeveelheid = 10,
                            LeverancierNaam = Guid.NewGuid().ToString(),
                            MinimumStock = 5,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = 7.00M,
                            Stocknr = Guid.NewGuid().ToString()
                        },
                };

            _getStockRefdataResponse = new GetStockRefdataResponse();
            _getStockRefdataResponse.Leveranciers = new List<LeverancierRefdata>();

            _getRefdataHandler = new Mock<IGetStockRefdataHandler>();
            _getRefdataHandler
                .Setup(x => x.Handle(It.IsAny<GetStockRefdataRequest>()))
                .Returns(_getStockRefdataResponse);
            Container
                .Setup(x => x.Resolve<IQueryHandler<GetStockRefdataRequest, GetStockRefdataResponse>>())
                .Returns(_getRefdataHandler.Object);

            _FilterStockHandler = new Mock<IFilterStockHandler>();
            _FilterStockHandler
                .Setup(x => x.Handle(It.IsAny<FilterStockRequest>()))
                .Returns(_FilterStockResponse);
            Container
                .Setup(x => x.Resolve<IQueryHandler<FilterStockRequest, FilterStockResponse>>())
                .Returns(_FilterStockHandler.Object);
            _GetStockOverzichtHandler = new Mock<IGetStockOverzichtHandler>();
            _GetStockOverzichtHandler
                .Setup(x => x.Handle(It.IsAny<GetStockOverzichtRequest>()))
                .Returns(_GetStockOverzichtResponse);
            Container
                .Setup(x => x.Resolve<IQueryHandler<GetStockOverzichtRequest, GetStockOverzichtResponse>>())
                .Returns(_GetStockOverzichtHandler.Object);
        }

        public override void Act()
        {
            _result = (ViewResult)Sut.Search(new StockFilterViewModel{
                ComponentTypeFilter = "",
                LeverancierFilter = 0,
                MancoFilter = true
            });
            _viewModel = (StockViewModel)_result.Model;
        }

        [Test]
        public void It_should_put_the_data_into_the_viewmodel()
        {
            _viewModel.List.ShouldMatchAllItemsOf(_FilterStockResponse.List.ToList(),
                (x, y) => x.Stocknr == y.Stocknr
                    && x.Hoeveelheid == y.Hoeveelheid
                    && x.LeverancierNaam == y.LeverancierNaam
                    && x.MinimumStock == y.MinimumStock
                    && x.Naam == y.Naam
                    && x.Opmerkingen == y.Opmerkingen
                    && x.Prijs == y.Prijs
                );
        }

        [Test]
        public void It_should_put_the_total_stock_value_into_the_viewmodel()
        {
            decimal totalStockValue = 0.00M;
            for (int i = 0;i < _GetStockOverzichtResponse.List.Count;i++) {
                totalStockValue += _GetStockOverzichtResponse.List[i].Hoeveelheid * _GetStockOverzichtResponse.List[i].Prijs;
            }
            Assert.AreEqual(_viewModel._totalStockValue,totalStockValue);
        }
    }
}