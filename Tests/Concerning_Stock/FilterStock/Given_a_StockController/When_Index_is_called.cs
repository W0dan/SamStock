using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SamStock.Stock.FilterStock;
using SamStock.Stock.GetStockRefdata;
using SamStock.Utilities;
using SamStock.Web.Models.Stock;
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
                            Quantity = 5,
                            SupplierName = Guid.NewGuid().ToString(),
                            MinimumStock = 10,
                            Name = Guid.NewGuid().ToString(),
                            Remark = Guid.NewGuid().ToString(),
                            Price = 12.25M,
                            Stocknr = Guid.NewGuid().ToString()
                        };
            FilterStockItem i2 = new FilterStockItem
                        {
                            Quantity = 2,
                            SupplierName = Guid.NewGuid().ToString(),
                            MinimumStock = 10,
                            Name = Guid.NewGuid().ToString(),
                            Remark = Guid.NewGuid().ToString(),
                            Price = 12.25M,
                            Stocknr = Guid.NewGuid().ToString()
                        };
            FilterStockItem i3 = new FilterStockItem {
                Quantity = 10,
                SupplierName = Guid.NewGuid().ToString(),
                MinimumStock = 5,
                Name = Guid.NewGuid().ToString(),
                Remark = Guid.NewGuid().ToString(),
                Price = 7.00M,
                Stocknr = Guid.NewGuid().ToString()
            };

            _FilterStockResponse = new FilterStockResponse();
            _FilterStockResponse.Components = new List<FilterStockItem>
                {
                    i1,i2
                };

            _totalStockResponse = new FilterStockResponse();
            _totalStockResponse.Components = new List<FilterStockItem>
            {
                i1,i2,i3
            };

            _getStockRefdataResponse = new GetStockRefdataResponse();
            _getStockRefdataResponse.Suppliers = new List<SupplierRefdata>();

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
                .Setup(x => x.Handle(It.Is<FilterStockRequest>(y => y.Manco == false && y.SupplierId <= 0 && y.StockNr == "")))
                .Returns(_totalStockResponse);
            Container
                .Setup(x => x.Resolve<IQueryHandler<FilterStockRequest, FilterStockResponse>>())
                .Returns(_FilterStockHandler.Object);
        }

        public override void Act()
        {
            _result = (ViewResult)Sut.Search(new StockFilterViewModel{
                ComponentTypeFilter = "",
                SupplierFilter = 0,
                MancoFilter = true
            });
            _viewModel = (StockViewModel)_result.Model;

            var tmp = (ViewResult)Sut.Search(new StockFilterViewModel {
                ComponentTypeFilter = "",
                SupplierFilter = 0,
                MancoFilter = false
            });
            _totalStockValue = ((StockViewModel)tmp.Model)._contentTotalValue;
        }

        [Test]
        public void It_should_put_the_data_into_the_viewmodel()
        {
            _viewModel.Components.ShouldMatchAllItemsOf(_FilterStockResponse.Components.ToList(),
                (x, y) => x.Stocknr == y.Stocknr
                    && x.Quantity == y.Quantity
                    && x.SupplierName == y.SupplierName
                    && x.MinimumStock == y.MinimumStock
                    && x.Name == y.Name
                    && x.Remark == y.Remarks
                    && x.Price == y.Price
                );
        }

        [Test]
        public void It_should_put_the_total_stock_value_into_the_viewmodel()
        {
            Assert.AreEqual(_viewModel._contentTotalValue,_totalStockValue);
        }
    }
}