using SAMStock.BO.Base;

namespace SAMStock.DAL.Base
{
	interface IBOCommandHandler<in TCommand, out TBO> where TCommand: IBOCommand<TBO> where TBO: IBO
	{
		TBO Handle(TCommand cmd);
	}
}
