﻿using System.Transactions;

namespace SAMStock.Utilities
{
    public static class TransactionScopeFactory
    {
        public static TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
}