﻿using System;
using System.Linq;
using System.Transactions;
using NUnit.Framework;
using SamStock.Database;
using SamStock.Utilities;

namespace Tests
{
    public abstract class DatabaseTest : BaseTest
    {
        private TransactionScope _transaction;

        public StockBeheerEntities Context { get; private set; }

        [TestFixtureSetUp]
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

        [TestFixtureTearDown]
        public override void CleanUp()
        {
            _transaction.Dispose();

            if (Context.Component.Any())
                throw new Exception(string.Format("Test cleanup failed: {0} components still exist in the test db", Context.Component.Count()));
        }

    }
}