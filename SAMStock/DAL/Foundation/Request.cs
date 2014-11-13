using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMStock.DAL.Foundation
{
	public abstract class Request<TResponse>: IRequest<TResponse> where TResponse: EventArgs, IResponse
	{
		public Object Sender { get; private set; }
		// public TResponse Response { get; private set; }

		// public event EventHandler<TResponse> Completed;

		protected Request(Object s)
		{
			Sender = s;
		}

		/* internal void Complete(TResponse r)
		{
			Response = r;
			Completed(null, r);
		} */
	}
}