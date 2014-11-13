using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.Update
{
	public class UpdatePedalHandler: BOCommandHandler<UpdatePedalCommand, Pedal>
	{
		public UpdatePedalHandler(IBOCommandExecutor<UpdatePedalCommand, Pedal> executor) : base(executor)
		{
		}
	}
}
