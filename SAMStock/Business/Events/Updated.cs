using SAMStock.Business.Foundation;

namespace SAMStock.Business.Events
{
	public class Updated<TBO>: Event<TBO> where TBO: IBusinessObject
	{
		public TBO BO { get; private set; }

		internal Updated(TBO bo)
		{
			BO = bo;
		} 
	}
}