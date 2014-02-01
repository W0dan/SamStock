﻿namespace SAMStock.DTO.Supplier.AddSupplier
{
	public class AddSupplierHandler : CommandHandler<AddSupplierCommand>
	{
		public AddSupplierHandler(ICommandExecutor<AddSupplierCommand> addLeverancierCommandExecutor): base(addLeverancierCommandExecutor)
		{
		}
	}
}