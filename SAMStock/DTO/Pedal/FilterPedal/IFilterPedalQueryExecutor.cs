using SAMStock.Utilities;

namespace SAMStock.DTO.Pedal.FilterPedal
{
	public interface IFilterPedalQueryExecutor : IQuery
	{
		FilterPedalResponse Execute(FilterPedalRequest request);
	}
}
