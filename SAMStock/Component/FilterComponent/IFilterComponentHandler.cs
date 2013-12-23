using SAMStock.Utilities;

namespace SAMStock.Component.FilterComponent
{
	public interface IFilterComponentHandler : IQueryHandler<FilterComponentRequest,FilterComponentResponse>
	{
		new FilterComponentResponse Handle(FilterComponentRequest request);
	}
}
