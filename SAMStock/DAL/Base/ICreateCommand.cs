using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	public interface ICreateCommand<TBO>: IBOCommand<TBO> where TBO: IBO
	{
	}
}
