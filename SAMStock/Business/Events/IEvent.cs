using SAMStock.Business.Foundation;

namespace SAMStock.Business.Events
{
	public interface IEvent<T> where T: IBusinessObject
	{
		long Id { get; }
	}
}
