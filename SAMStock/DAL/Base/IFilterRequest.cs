using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	public interface IFilterRequest<TBO>: IRequest where TBO: IBO
	{
		int? Id { get; set; }
	}
}
