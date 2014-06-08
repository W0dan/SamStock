using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	public interface IBOCommandExecutor<in TCOmmand, out TBO> where TCOmmand: IBOCommand<TBO> where TBO: IBO
	{
		TBO Execute(TCOmmand cmd);
	}
}
