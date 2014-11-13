using SAMStock.Business.Foundation;

namespace SAMStock.Business.Events
{
	public class Created<TBO>: Event<TBO> where TBO: IBusinessObject
	{
		public TBO BO { get; private set; }

		internal Created(TBO bo)
		{
			BO = bo;
		}
	}
}
