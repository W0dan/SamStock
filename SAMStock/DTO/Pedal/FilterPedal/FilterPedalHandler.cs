using System.Collections.Generic;
using System.Linq;
using SAMStock.DTO.Admin.GetAdminData;

namespace SAMStock.DTO.Pedal.FilterPedal
{
	public class FilterPedalHandler : RequestHandler<FilterPedalRequest, FilterPedalResponse>
	{
		public FilterPedalHandler(IRequestExecutor<FilterPedalRequest, FilterPedalResponse> queryexecutor): base(queryexecutor)
		{
		}
	}
}
