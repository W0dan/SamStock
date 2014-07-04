using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	// ReSharper disable InconsistentNaming
	public interface IBOCommandExecutor<in TCOmmand, out TBO> where TCOmmand: IBOCommand<TBO> where TBO: IBO
	// ReSharper restore InconsistentNaming
	{
		TBO Execute(TCOmmand cmd);
	}
}
