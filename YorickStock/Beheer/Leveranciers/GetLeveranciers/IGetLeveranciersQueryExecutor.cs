using SamStock.Utilities;

namespace SamStock.Beheer.Leveranciers.GetLeveranciers {
    //Opmerking: inherit from IQuery in order to let Castle Windsor know it has to register it
    public interface IGetLeveranciersQueryExecutor : IQuery {
        GetLeveranciersResponse Execute(GetLeveranciersRequest request);
    }
}
