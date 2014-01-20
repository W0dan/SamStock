using SAMStock.Utilities;

namespace SAMStock.DTO.Pedal.FilterPedal
{
	public interface IFilterPedalHandler : IQueryHandler<FilterPedalRequest, FilterPedalResponse>
	{
		new FilterPedalResponse Handle(FilterPedalRequest request);
	}
}