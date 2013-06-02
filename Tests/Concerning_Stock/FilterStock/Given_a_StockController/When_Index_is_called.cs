using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Stock.FilterStock;
using SamStock.Stock.GetStockRefdata;
using SamStock.Utilities;
using SamStock.Web.Models;
using Tests._Util;

namespace Tests.Concerning_Stock.FilterStock.Given_a_StockController
{
    [TestFixture]
    public class When_Index_is_called : StockControllerBaseTest
    {
        private Mock<IFilterStockHandler> _FilterStockHandler;
        private ViewResult _result;
        private StockViewModel _viewModel;
        private FilterStockResponse _FilterStockResponse, _totalStockResponse;
        private Mock<IGetStockRefdataHandler> _getRefdataHandler;
        private GetStockRefdataResponse _getStockRefdataResponse;
        decimal _totalStockValue;

        public override void Arrange()
        {
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
            FilterStockItem i3 = new FilterStockItem {
                Hoeveelheid = 10,
                LeverancierNaam = Guid.NewGuid().ToString(),
                MinimumStock = 5,
                Naam = Guid.NewGuid().ToString(),
                Opmerkingen = Guid.NewGuid().ToString(),
                Prijs = 7.00M,
                Stocknr = Guid.NewGuid().ToString()
            };

            _FilterStockResponse = new FilterStockResponse();
            _FilterStockResponse.List = new List<FilterStockItem>
                {
                    i1,i2
                };

            _totalStockResponse = new FilterStockResponse();
            _totalStockResponse.List = new List<FilterStockItem>
            {
                i1,i2,i3
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
                .Setup(x => x.Handle(It.Is<FilterStockRequest>(y => y.Manco == true)))
                .Returns(_FilterStockResponse);
            _FilterStockHandler
                .Setup(x => x.Handle(It.Is<FilterStockRequest>(y => y.Manco == false && y.LeverancierID <= 0 && y.StockNr == "")))
                .Returns(_totalStockResponse);
            Container
                .Setup(x => x.Resolve<IQueryHandler<FilterStockRequest, FilterStockResponse>>())
                .Returns(_FilterStockHandler.Object);
        }

        public override void Act()
        {
            _result = (ViewResult)Sut.Search(new StockFilterViewModel{
                ComponentTypeFilter = "",
                LeverancierFilter = 0,
                MancoFilter = true
            });
            _viewModel = (StockViewModel)_result.Model;

            var tmp = (ViewResult)Sut.Search(new StockFilterViewModel {
                ComponentTypeFilter = "",
                LeverancierFilter = 0,
                MancoFilter = false
            });
            _totalStockValue = ((StockViewModel)tmp.Model)._contentTotalValue;
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
            Assert.AreEqual(_viewModel._contentTotalValue,_totalStockValue);
        }
    }
}