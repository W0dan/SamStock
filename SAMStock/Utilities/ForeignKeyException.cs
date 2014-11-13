using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace SAMStock.Utilities
{
	public class ForeignKeyException : Exception
	{
		public int ReferredId { get; private set; }
		public List<int> ReferrerIds { get; private set; }
		public string ReferrersType { get; private set; }

		public ForeignKeyException(int referredid, IEnumerable<int> referrerids, string tablename)
			: base(String.Format("The entity with Id={0} is referred to by {1} entities with Id={2} and cannot be deleted.", referredid, tablename, referrerids.Join(", ")))
		{
			ReferredId = referredid;
			ReferrerIds = referrerids.ToList();
			ReferrersType = tablename;
		}
	}
}