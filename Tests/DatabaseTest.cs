using System;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SAMStock.Database;
using SAMStock.Utilities;

namespace Tests
{
	[TestClass]
    public abstract class DatabaseTest : BaseTest
    {
        private TransactionScope _transaction;
        protected IContext Context { get; private set; }

        [TestInitialize]
        public override void Setup()
        {
            _transaction = TransactionScopeFactory.CreateTransactionScope();
            try
            {
                Context = new SAMStockEntities();

                Arrange();
                Context.SaveChanges();
                Act();
                Context.SaveChanges();
            }
            catch (Exception)
            {
                _transaction.Dispose();
                throw;
            }
        }

        [TestCleanup]
        public override void CleanUp()
        {
            _transaction.Dispose();
        }
    }
}