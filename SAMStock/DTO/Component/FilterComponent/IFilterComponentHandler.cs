using SAMStock.Utilities;

namespace SAMStock.DTO.Component.FilterComponent
{
	public interface IFilterComponentHandler : IQueryHandler<FilterComponentRequest,FilterComponentResponse>
	{
		new FilterComponentResponse Handle(FilterComponentRequest request);
	}
}
