using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Stock.FilterStock;
using SamStock.Stock.GetStockOverzicht;
using SamStock.Stock.GetStockOverzichtRefdata;
using SamStock.Utilities;
using SamStock.Web.Models;
using Tests._Util;

namespace Tests.Concerning_Stock.FilterStock.Given_a_StockController
{
    public class When_Index_is_called : StockControllerBaseTest
    {
        private Mock<IFilterStockHandler> _FilterStockHandler;
        private ViewResult _result;
        private StockViewModel _viewModel;
        private FilterStockResponse _FilterStockResponse;
        private Mock<IGetStockRefdataHandler> _getRefdataHandler;
        private GetStockRefdataResponse _getStockRefdataResponse;

        public override void Arrange()
        {
            _FilterStockResponse = new FilterStockResponse();
            _FilterStockResponse.List = new List<FilterStockItem>
                {
                    new FilterStockItem
                        {
                            Hoeveelheid = 5,
                            LeverancierNaam = Guid.NewGuid().ToString(),
                            MinimumStock = 10,
                            Naam = Guid.NewGuid().ToString(),
                            Opmerkingen = Guid.NewGuid().ToString(),
                            Prijs = 12.25M,
                            Stocknr = Guid.NewGuid().ToString()
                        },
                    new FilterStockItem
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
        }

        public override void Act()
        {
            _result = (ViewResult)Sut.FindMancos(new StockFilterViewModel{
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
    }
}