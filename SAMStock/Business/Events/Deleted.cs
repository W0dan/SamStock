using SAMStock.Business.Foundation;

namespace SAMStock.Business.Events
{
	public class Deleted<TBO>: Event<TBO> where TBO: IBusinessObject
	{
		public int BOId { get; private set; }

		internal Deleted(int id)
		{
			BOId = id;
		}
	}
}
