﻿namespace SAMStock.DAL.Pedal.AddPedal
{
	public class AddPedalCommandHandler : CommandHandler<AddPedalCommand>
	{
		public AddPedalCommandHandler(ICommandExecutor<AddPedalCommand> cmdexecutor): base(cmdexecutor)
		{
		}
	}
}