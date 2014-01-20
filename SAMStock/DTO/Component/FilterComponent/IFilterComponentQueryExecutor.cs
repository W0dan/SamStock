using SAMStock.Utilities;

namespace SAMStock.DTO.Component.FilterComponent
{
	public interface IFilterComponentQueryExecutor : IQuery
	{
		FilterComponentResponse Execute(FilterComponentRequest request);
	}
}
