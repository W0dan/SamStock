using System;
using System.Transactions;
using YorickStock.Database;
using YorickStock.Utilities;

namespace Tests
{
    public abstract class DatabaseTest : BaseTest
    {
        private TransactionScope _transaction;

        public StockBeheerEntities Context { get; private set; }

        public override void Setup()
        {
            _transaction = TransactionScopeFactory.CreateTransactionScope();
            try
            {
                Context = new StockBeheerEntities();

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

        protected override void CleanUp()
        {
            _transaction.Dispose();
        }

    }
}