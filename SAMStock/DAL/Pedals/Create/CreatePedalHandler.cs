using SAMStock.BO;
using SAMStock.Business;
using SAMStock.Business.Objects;
using SAMStock.DAL.Foundation;

namespace SAMStock.DAL.Pedals.Create
{
	public class CreatePedalHandler: BOCommandHandler<CreatePedalCommand, Pedal>
	{
		public CreatePedalHandler(IBOCommandExecutor<CreatePedalCommand, Pedal> executor) : base(executor)
		{
		}
	}
}
