using System;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Foundation
{
	public interface IRequest<TResponse> where TResponse: IResponse
	{
		Object Sender { get; }
	}
}