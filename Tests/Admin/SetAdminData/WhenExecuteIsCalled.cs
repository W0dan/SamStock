using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SAMStock.DTO.Admin.SetAdminData;

namespace Tests.Admin.SetAdminData
{
	[TestFixture]
	public class WhenExecuteIsCalled: DatabaseTest
	{
		private SetAdminDataCommand _cmd;
		private SetAdminDataCommandExecutor _sut;

		public override void Arrange()
		{
			_cmd = new SetAdminDataCommand
			{
				DefaultPedalPriceMargin = 10,
				VAT = 21
			};
			_sut = new SetAdminDataCommandExecutor(Context);
		}

		public override void Act()
		{
			_sut.Execute(_cmd);
		}
		[Test]
		public void It_should_store_the_correct_DefaultPedalPriceMargin()
		{
			Assert.AreEqual(_cmd.DefaultPedalPriceMargin, Context.AdminData.Single().DefaultPedalPriceMargin);
		}

		[Test]
		public void It_should_store_the_correct_VAT()
		{
			Assert.AreEqual(_cmd.VAT, Context.AdminData.Single().VAT);
		}
	}
}
