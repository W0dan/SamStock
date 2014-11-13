using SAMStock.Business.Events;
using SAMStock.Castle;

namespace SAMStock.Business.Foundation
{
	public interface IManager<T>: IEventSource<T>, IResolvable where T: IBusinessObject
	{
	}
}
