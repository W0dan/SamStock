using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.DAL.Component.DeleteComponent;

namespace Tests.Components.DeleteComponent.DeleteComponentQueryExecutor
{
	[TestFixture]
	public class WhenExecuteIsCalled: DatabaseTest
	{
		private DeleteComponentCommand _cmd;
		private DeleteComponentCommandExecutor _sut;
		private Component _c1, _c2;

		public override void Arrange()
		{
			var s = new Supplier
            {
	            Name = "Jack"
            };
            Context.Supplier.AddObject(s);
			Context.SaveChanges();

			_c1 = new Component
			{
				ItemCode = "abc1234",
				MinimumStock = 5,
				Name = "Comp",
				Price = 20,
				Stock = 10,
				Remarks = "",
				Stocknr = "125",
				SupplierId = Context.Supplier.Single().Id
			};
			_c2 = new Component
			{
				ItemCode = "978751a",
				MinimumStock = 10,
				Name = "OtherComp",
				Price = 20,
				Stock = 10,
				Remarks = "abx",
				Stocknr = "15",
				SupplierId = Context.Supplier.Single().Id
			};
			Context.Component.AddObject(_c1);
			Context.Component.AddObject(_c2);
			Context.SaveChanges();

			_cmd = new DeleteComponentCommand
			{
				Id = Context.Component.Single(x => x.Stocknr == _c2.Stocknr).Id
			};

			_sut = new DeleteComponentCommandExecutor(Context);
		}

		public override void Act()
		{
			_sut.Execute(_cmd);
		}

		[Test]
		public void It_should_delete_the_right_Component()
		{
			Assert.IsTrue(Context.Component.Any(x => x.Stocknr == _c1.Stocknr));
			Assert.IsFalse(Context.Component.Any(x => x.Stocknr == _c2.Stocknr));
		}
	}
}
