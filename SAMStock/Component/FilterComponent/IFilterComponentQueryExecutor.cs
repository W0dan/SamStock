using SAMStock.Utilities;

namespace SAMStock.Component.FilterComponent
{
	public interface IFilterComponentQueryExecutor : IQuery
	{
		FilterComponentResponse Execute(FilterComponentRequest request);
	}
}
