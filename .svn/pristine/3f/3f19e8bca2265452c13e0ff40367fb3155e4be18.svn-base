using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.DAL.Admin.GetAdminData;
using SAMStock.DAL.Pedal.AddPedal;

namespace Tests.Admin.GetAdminData.GetAdminDataQueryExecutor
{
	[TestFixture]
	public class WhenExecuteIsCalled: DatabaseTest
	{
		private GetAdminDataRequest _req;
		private SAMStock.DAL.Admin.GetAdminData.GetAdminDataRequestExecutor _sut;
		private GetAdminDataResponse _resp;
		private AdminData _data;

		public override void Arrange()
		{
			_req = new GetAdminDataRequest();
			_sut = new SAMStock.DAL.Admin.GetAdminData.GetAdminDataRequestExecutor(Context);
			_data = Context.AdminData.Single();
		}

		public override void Act()
		{
			_resp = _sut.Execute(_req);
		}

		[Test]
		public void It_should_return_the_correct_DefaultPedalPriceMargin()
		{
			Assert.AreEqual(_data.DefaultPedalPriceMargin, Context.AdminData.Single().DefaultPedalPriceMargin);
		}

		[Test]
		public void It_should_return_the_correct_VAT()
		{
			Assert.AreEqual(_data.VAT, Context.AdminData.Single().VAT);
		}
	}
}
