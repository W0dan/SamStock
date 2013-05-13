using SamStock.Utilities;

namespace SamStock.Beheer.Leveranciers.GetLeveranciers {
    public interface IGetLeveranciersQueryExecutor : IQuery {
        GetLeveranciersResponse Execute(GetLeveranciersRequest request);
    }
}
