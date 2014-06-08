using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	public interface IUpdateCommand<TBO>: IBOCommand<TBO> where TBO: IBO
	{
	}
}
