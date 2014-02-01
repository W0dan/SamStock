namespace SAMStock.DTO.Supplier.UpdateSupplier
{
	public class UpdateSupplierCommandHandler: CommandHandler<UpdateSupplierCommand>
	{
		public UpdateSupplierCommandHandler(ICommandExecutor<UpdateSupplierCommand> executor): base(executor)
		{
		}
	}
}
